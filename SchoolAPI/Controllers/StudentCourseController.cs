using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private SchoolContext _context;

        // GET: api/<StudentCourseController>
        [HttpGet]
        public IEnumerable<StudentCourse> Get()
        {
            return _context.StudentCourses.ToList();
        }

        // GET api/<StudentCourseController>/5
        [HttpGet("{id}")]
        public StudentCourse Get(int id)
        {
            return _context.StudentCourses
                .Where(StudentCourse => StudentCourse.StudentCourseID == id)
                .FirstOrDefault();
        }

        // POST api/<StudentCourseController>
        [HttpPost]
        public IActionResult Post([FromBody] StudentCourse studentCourse)
        {
            _context.StudentCourses.Add(studentCourse);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<StudentCourseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.Remove(_context.StudentCourses
                .Where(sc => sc.StudentCourseID == id)
                .FirstOrDefault());

            _context.SaveChanges();
            return Ok();
        }
    }
}
