using crude_System_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crude_System_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class StudentsController : ControllerBase
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1,Name="misk",Description="test"},
             new Student { Id = 2,Name="misk1",Description="test"},
              new Student { Id = 3,Name="misk2",Description="test"}
        };

        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            return Ok(students);

        }
        [HttpGet("{id}")]

        public IActionResult getById(int id)
        {
            var student = students.Find(x=>x.Id==id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]

        public IActionResult Add(Student request)
        {
            if(request == null)
            {
                return BadRequest();
            }

            var student = new Student 
            { 
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            
            };
            students.Add(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id ,Student request)
        {
            var currentStudent  = students.FirstOrDefault(x=>x.Id==id);
            if(currentStudent == null)
            {
                return BadRequest();
            }
            currentStudent.Name = request.Name;
            currentStudent.Description = request.Description;

            return Ok(currentStudent);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var currentStudent = students.FirstOrDefault(x => x.Id == id);
            if (currentStudent == null)
            {
                return BadRequest();
            }
           
            students.Remove(currentStudent);

            return Ok();
        }
    }
}
