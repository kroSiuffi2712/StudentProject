using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository) {
            _studentRepository = studentRepository ?? new StudentRepository();
        }

        // GET: api/Students
        [HttpGet]
        public async Task<IEnumerable<StudentViewModel>> GetStudent()
        {
            return await _studentRepository.GetStudents();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _studentRepository.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent([FromRoute] int id, [FromBody] StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.Id)
            {
                return BadRequest();
            }

            var response = await _studentRepository.UpdateStudentAsync(id,student);
            if (response.IsValid == false)
            {
                return NotFound();
            }
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // POST: api/Students
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _studentRepository.CreateStudentAsync(student);
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _studentRepository.DeleteStudentByIdAsync(id);
            if (response.IsValid == false)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}