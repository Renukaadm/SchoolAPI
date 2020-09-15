using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class CoursePoco
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentCoursePoco> studentCourses { get; set; }

    }
}
