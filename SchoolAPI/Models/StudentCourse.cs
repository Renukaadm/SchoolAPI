using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class StudentCourse
    {
        [Key]
        public int StudentCourseID { get; set; }
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public virtual Student student { get; set; }
        public virtual Course course { get; set; }
    }
}
