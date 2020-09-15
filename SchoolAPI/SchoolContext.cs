using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options) { }

        public SchoolContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCoursePoco>().HasKey(sc => new { sc.StudentID, sc.CourseID });

            builder.Entity<StudentCoursePoco>()
                .HasOne<StudentPoco>(sc => sc.Student)
                .WithMany(s => s.studentCourses)
                .HasForeignKey(sc => sc.StudentID);


            builder.Entity<StudentCoursePoco>()
                .HasOne<CoursePoco>(sc => sc.Course)
                .WithMany(s => s.studentCourses)
                .HasForeignKey(sc => sc.CourseID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("SchoolDB");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<StudentPoco> Students { get; set; }
        public DbSet<CoursePoco> Courses { get; set; }
        public DbSet<StudentCoursePoco> StudentCourses { get; set; }

        

        
    }
}
