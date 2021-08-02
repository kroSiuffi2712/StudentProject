using Data;
using DBManger.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBManger.Student
{
    public class StudentDbRepository : IStudentDbRepository
    {
        public async Task<OperationResponse> CreateStudentAsync(Data.Dto.Student studentDto)
        {
            try
            {
                int result;
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Students.Add(new Entities.Student { Id = studentDto.Id, UserName = studentDto.UserName, FirstName = studentDto.FirstName, LastName = studentDto.LastName, Age = studentDto.Age, Career = studentDto.Career });
                    result = await dbContext.SaveChangesAsync();
                }

                return new OperationResponse { IsValid = result > 0, Key = result, Message = "Student has been added sucessfully" };

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OperationResponse> DeleteStudentByIdAsync(int studentId)
        {
            try
            {
                int result;
                using (var dbContext = new MyDbContext())
                {
                    var student = await dbContext.Students.FindAsync(studentId);
                    dbContext.Remove(student);
                    result = dbContext.SaveChanges();
                }

                return new OperationResponse { IsValid = result > 0, Key = result, Message = "Delete the student" };

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Data.Dto.Student> GetStudentByIdAsync(int studentId)
        {
            try
            {
                Data.Dto.Student studentDto;
                using (var dbContext = new MyDbContext())
                {
                    var student = await dbContext.Students.FindAsync(studentId);
                    studentDto = new Data.Dto.Student() { Id = student.Id, UserName = student.UserName, FirstName = student.FirstName, LastName = student.LastName, Age = student.Age, Career = student.Career };
                }

                return studentDto;

            } catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<OperationResponse> UpdateStudentAsync(int id,Data.Dto.Student studentDto)
        {
            try
            {
                int result;
                using (var dbContext = new MyDbContext())
                {
                    var student = await dbContext.Students.FindAsync(id);
                    student.UserName = studentDto.UserName;
                    student.FirstName = studentDto.FirstName;
                    student.LastName = studentDto.LastName;
                    student.Age = studentDto.Age;
                    student.Career = studentDto.Career;

                    result = dbContext.SaveChanges();
                }

                return new OperationResponse { IsValid = result > 0, Key = result, Message = "Delete the student" };

            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<List<Data.Dto.Student>> GetStudents()
        {
            try
            {
                List<Data.Dto.Student> studentsDto = new List<Data.Dto.Student>();
                using (var dbContext = new MyDbContext())
                {
                    var students = await dbContext.Students.ToListAsync();
                    studentsDto = MapStudents(students);
                }
                return studentsDto;
            }catch (Exception ex) {
                throw ex;
            }
        }

        #region
        private List<Data.Dto.Student> MapStudents(List<Entities.Student> students)
        {

            List<Data.Dto.Student> studentsList = new List<Data.Dto.Student>();
            students.ForEach(s =>
            {
                var student = new Data.Dto.Student() { Id = s.Id, UserName = s.UserName, FirstName = s.FirstName, LastName = s.LastName, Age = s.Age, Career = s.Career };
                studentsList.Add(student);
            });
            return studentsList;
        }
        #endregion
    }
}
