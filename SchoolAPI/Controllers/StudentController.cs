using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private SchoolContext _context = new SchoolContext();

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.Students.ToList();
        }


        // GET api/<StudentController>/5
        [HttpGet("{ID}")]
        public Student Get(int id)
        {
            return _context.Students
                .Where(student => student.StudentID == id)
                .FirstOrDefault();
            
        }


        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            student.StudentID = _context.Students.Select(student => student.StudentID).Max() + 1;
            
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok();
        }


        // DELETE api/<StudentController>/5
        //[httpdelete("{id}")]
        //public iactionresult delete(int id)
        //{

        //    _context.remove(_context.students
        //        .where(s => s.studentid == id)
        //        .firstordefault());

        //    _context.savechanges();
        //    return ok();

        //}
    }
}
