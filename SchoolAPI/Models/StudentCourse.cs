using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class StudentCourse
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public Student student { get; set; }
        public Course course { get; set; }
    }
}
