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
    public class CourseController : ControllerBase
    {
        //private SchoolContext _context = new SchoolContext();
        private CourseLogic _courseLogic;

        public CourseController()
        {
            _courseLogic = new CourseLogic(new EFGenericRepository<CoursePoco>());
        }

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<CoursePoco> Get()
        {
            return _courseLogic.GetAll();
        }


        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public CoursePoco Get(int id)
        {
            return _courseLogic.GetSingle(id);
        }


        // POST api/<CourseController>
        [HttpPost]
        public IActionResult Post([FromBody] CoursePoco course)
        {
            _courseLogic.Add(course);
            return Ok();
        }


        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseLogic.Remove(id);
            return Ok();
        }
    }
}
