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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("SchoolDB");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        

        
    }
}
