using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class StudentPoco
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public ICollection<StudentCoursePoco> studentCourses { get; set; }
    }
}
