using Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dto = Data.Dto;
namespace DBManger.Student
{
    public interface IStudentDbRepository
    {
        Task<OperationResponse> CreateStudentAsync(Dto.Student studentDto);
        Task<OperationResponse> DeleteStudentByIdAsync(int studentId);
        Task<OperationResponse> UpdateStudentAsync(int id,Dto.Student studentDto);

        Task<Data.Dto.Student> GetStudentByIdAsync(int studentId);
        Task<List<Data.Dto.Student>> GetStudents();
    }
}
