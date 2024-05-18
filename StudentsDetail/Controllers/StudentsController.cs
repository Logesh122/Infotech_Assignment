using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsDetail.Data;
using StudentsDetail.Models;
using StudentsDetail.Repository;

namespace StudentsDetail.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        
        private readonly IStudentRepository studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
         
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
           var students= await studentRepository.GetStudents();
            return Ok(students);
            
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetStudentsById([FromRoute]Guid id)
        {
          
            var student= await studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
       
        public async Task<IActionResult> AddStudentDetails([FromBody]Students students)
        {
            var student = await studentRepository.AddStudent(students);
           
            return CreatedAtAction(nameof(GetStudentsById), new { id = student.Id }, student);

        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult>UpdateStudentDetails([FromRoute]Guid id,[FromBody]UpdateStudents updateStudents)
        {
            var UpdatedStudents = await studentRepository.UpdateStudent(id, updateStudents);
           
            if (UpdatedStudents == null)
            {
                return BadRequest();
            }
            return Ok(UpdatedStudents);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteStudentDetails([FromRoute] Guid id)
        {
           var deletedStudent= await studentRepository.DeleteStudent(id);

            if (deletedStudent == null)
            {
                return BadRequest();
            }
            return Ok(deletedStudent);
        }

    }
}
