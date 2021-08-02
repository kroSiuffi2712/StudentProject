using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Student
{
    public interface IStudentManagerRepository
    {
        Task<OperationResponse> CreateStudentAsync(Data.Dto.Student studentDto);
        Task<OperationResponse> DeleteStudentByIdAsync(int studentId);
        Task<OperationResponse> UpdateStudentAsync(int id, Data.Dto.Student studentDto);

        Task<Data.Dto.Student> GetStudentByIdAsync(int studentId);
        Task<List<Data.Dto.Student>> GetStudents();
    }
}
