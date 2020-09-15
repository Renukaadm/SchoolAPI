using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentLogic _studentLogic;

        public StudentController()
        {
            _studentLogic = new StudentLogic(new EFGenericRepository<StudentPoco>());
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<StudentPoco> Get()
        {
            return _studentLogic.GetAll();
        }

   

        // GET api/<StudentController>/5
        [HttpGet("{ID}")]
        public StudentPoco Get(int id)
        {
            return _studentLogic.GetSingle(id);
        }


        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] StudentPoco student)
        {
            _studentLogic.Add(student);
            return Ok();
        }


         //DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentLogic.Remove(id);
            return Ok();

        }
    }
}
