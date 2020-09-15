using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Models;

namespace SchoolAPI.Logic
{
    public class StudentCourseLogic
    {
        private EFGenericRepository<StudentCoursePoco> _eFGenericRepository;

        public StudentCourseLogic(EFGenericRepository<StudentCoursePoco> eFGenericRepository)
        {
            _eFGenericRepository = eFGenericRepository;
        }

        public IEnumerable<StudentCoursePoco> GetAll()
        {
            return _eFGenericRepository.GetAll();
        }


        public StudentCoursePoco GetSingle(int id)
        {
            return _eFGenericRepository.GetSingle(studentCourse => studentCourse.StudentCourseID == id);
        }


        public void Add(StudentCoursePoco studentCourse)
        {
            _eFGenericRepository.Add(studentCourse);
        }


        public void Remove(int id)
        {
            StudentCoursePoco studentCourse = _eFGenericRepository.GetSingle(studentCourse => studentCourse.StudentCourseID == id);
            _eFGenericRepository.Remove(studentCourse);
        }
    }
}
