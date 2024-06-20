using crude_System_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crude_System_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1,Name="misk",Description="test"},
             new Product { Id = 2,Name="misk1",Description="test"},
              new Product { Id = 3,Name="misk2",Description="test"}
        };

        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            return Ok(products);

        }
        [HttpGet("{id}")]

        public IActionResult getById(int id)
        {
            var student = products.Find(x=>x.Id==id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]

        public IActionResult Add(Product request)
        {
            if(request == null)
            {
                return BadRequest();
            }

            var student = new Product 
            { 
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            
            };
            products.Add(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id ,Product request)
        {
            var currentStudent  = products.FirstOrDefault(x=>x.Id==id);
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
            var currentStudent = products.FirstOrDefault(x => x.Id == id);
            if (currentStudent == null)
            {
                return BadRequest();
            }
           
            products.Remove(currentStudent);

            return Ok();
        }
    }
}
