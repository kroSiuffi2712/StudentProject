using Manager.Student;
using StudentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dto = Data.Dto;

namespace StudentAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IStudentManagerRepository _studentManagerRepository;

        public StudentRepository():this(null) { }

        public StudentRepository(IStudentManagerRepository studentManagerRepository) {
            _studentManagerRepository = studentManagerRepository ?? new StudentManagerRepository();
        }

        public async Task<ResponseViewModel> CreateStudentAsync(StudentViewModel student)
        {
            var studentDto = new Dto.Student() { Id = student.Id, UserName = student.UserName, FirstName = student.FirstName, LastName = student.LastName, Age = student.Age, Career = student.Career };
            var operationResponse = await _studentManagerRepository.CreateStudentAsync(studentDto);
            return new ResponseViewModel() { IsValid = operationResponse.IsValid, Key = operationResponse.Key, Message = operationResponse.Message };
        }

        public async Task<ResponseViewModel> DeleteStudentByIdAsync(int studentId)
        {
            var operationResponse = await _studentManagerRepository.DeleteStudentByIdAsync(studentId);
            return new ResponseViewModel() { IsValid = operationResponse.IsValid, Key = operationResponse.Key, Message = operationResponse.Message };
        }

        public async Task<StudentViewModel> GetStudentByIdAsync(int studentId)
        {
            var student = await _studentManagerRepository.GetStudentByIdAsync(studentId);
            return new StudentViewModel() { Id = student.Id, UserName = student.UserName, FirstName = student.FirstName, LastName = student.LastName, Age = student.Age, Career = student.Career };
        }

        public async Task<List<StudentViewModel>> GetStudents()
        {
            var studentListDto = await _studentManagerRepository.GetStudents();
            var studentsView = MapStudents(studentListDto);
            return studentsView;
        }

        public async Task<ResponseViewModel> UpdateStudentAsync(int id,StudentViewModel studentModel)
        {
            var studentDto = new Dto.Student() { Id = studentModel.Id, UserName = studentModel.UserName, FirstName = studentModel.FirstName, LastName = studentModel.LastName, Age = studentModel.Age, Career = studentModel.Career };
            var operationResponse = await _studentManagerRepository.UpdateStudentAsync(id,studentDto);
            return new ResponseViewModel() { IsValid = operationResponse.IsValid, Key = operationResponse.Key, Message = operationResponse.Message };

        }

        #region
        private List<StudentViewModel> MapStudents(List<Dto.Student> students) {
            var studentViewList = new List<StudentViewModel>();
            students.ForEach(student =>
            {
                studentViewList.Add(new StudentViewModel() { Id = student.Id, UserName = student.UserName, FirstName = student.FirstName, LastName = student.LastName, Age = student.Age, Career = student.Career });
            });

            return studentViewList;
        }
        #endregion
    }
}
