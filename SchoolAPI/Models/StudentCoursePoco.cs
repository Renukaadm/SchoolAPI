using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class StudentCoursePoco
    {
        [Key]
        public int StudentCourseID { get; set; }
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public StudentPoco Student { get; set; }
        public CoursePoco Course { get; set; }
    }
}
