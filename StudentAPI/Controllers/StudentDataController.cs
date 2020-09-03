using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Data;
using Students.Services;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {
        private readonly IStudent db;

        public StudentDataController(IStudent _db)
        {
            db = _db;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Student _student)
        {
            if (_student == null)
            {
                return BadRequest();
            }
            POJO model = await db.Save(_student);
            if(model == null)
            {
                return NotFound();
            }
            
            return Ok(model);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudent(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            Student model = await db.GetStudent(Id);
            if(model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            IQueryable<Student> data = db.GetStudents;
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            POJO model = await db.DeleteAsync(Id);
            if (model == null)
            {
                return NotFound();
            }
           // db.Delete(Id);
            return Ok(model);
        }
    }
}
