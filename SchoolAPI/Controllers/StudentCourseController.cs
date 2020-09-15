using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Logic;
using SchoolAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private StudentCourseLogic _studentCourseLogic;

        public StudentCourseController()
        {
            _studentCourseLogic = new StudentCourseLogic(new EFGenericRepository<StudentCoursePoco>());
        }

        // GET: api/<StudentCourseController>
        [HttpGet]
        public IEnumerable<StudentCoursePoco> Get()
        {
            return _studentCourseLogic.GetAll();
        }

        // GET api/<StudentCourseController>/5
        [HttpGet("{id}")]
        public StudentCoursePoco Get(int id)
        {
            return _studentCourseLogic.GetSingle(id);
        }

        // POST api/<StudentCourseController>
        [HttpPost]
        public IActionResult Post([FromBody] StudentCoursePoco studentCourse)
        {
            _studentCourseLogic.Add(studentCourse);
            return Ok();
        }

        // DELETE api/<StudentCourseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentCourseLogic.Remove(id);
            return Ok();
        }
    }
}
