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
        public IActionResult Save([FromBody] Student data)
        {
            if (data == null)
            {
                return BadRequest();
            }
            db.Save(data);
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public IActionResult GetStudent(int? Id)
        {
            Student data = db.GetStudent(Id);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            IQueryable<Student> data = db.GetStudents;
            return Ok(data);
        }

        [HttpDelete]
        public IActionResult Delete(int? Id)
        {
            db.Delete(Id);
            return Ok();
        }
    }
}
