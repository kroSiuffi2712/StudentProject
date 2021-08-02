using StudentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Repository
{
    public interface IStudentRepository
    {
        Task<ResponseViewModel> CreateStudentAsync(StudentViewModel student);
        Task<ResponseViewModel> DeleteStudentByIdAsync(int studentId);
        Task<ResponseViewModel> UpdateStudentAsync(int id, StudentViewModel student);

        Task<StudentViewModel> GetStudentByIdAsync(int studentId);
        Task<List<StudentViewModel>> GetStudents();
    }
}
