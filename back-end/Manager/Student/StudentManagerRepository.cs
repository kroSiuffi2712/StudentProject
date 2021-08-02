using Data;
using DBManger.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Student
{
    public class StudentManagerRepository : IStudentManagerRepository
    {
        private readonly IStudentDbRepository _studentDbRepository;

        public StudentManagerRepository() : this(null) { }

        public StudentManagerRepository(IStudentDbRepository studentDbRepository) {
            _studentDbRepository = studentDbRepository ?? new StudentDbRepository();
        }

        public Task<OperationResponse> CreateStudentAsync(Data.Dto.Student studentDto)
        {
            return _studentDbRepository.CreateStudentAsync(studentDto);
        }

        public Task<OperationResponse> DeleteStudentByIdAsync(int studentId)
        {
            return _studentDbRepository.DeleteStudentByIdAsync(studentId);
        }

        public Task<Data.Dto.Student> GetStudentByIdAsync(int studentId)
        {
            return _studentDbRepository.GetStudentByIdAsync(studentId);
        }

        public Task<List<Data.Dto.Student>> GetStudents()
        {
            return _studentDbRepository.GetStudents();
        }

        public Task<OperationResponse> UpdateStudentAsync(int id,Data.Dto.Student studentDto)
        {
            return _studentDbRepository.UpdateStudentAsync(id, studentDto);
        }
    }
}
