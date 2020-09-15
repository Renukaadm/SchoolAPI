using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Models;

namespace SchoolAPI.Logic
{
    public class CourseLogic
    {
        private EFGenericRepository<CoursePoco> _eFGenericRepository;

        public CourseLogic(EFGenericRepository<CoursePoco> eFGenericRepository)
        {
            _eFGenericRepository = eFGenericRepository;
        }

        public IEnumerable<CoursePoco> GetAll()
        {
            return _eFGenericRepository.GetAll();
        }


        public CoursePoco GetSingle(int id)
        {
            return _eFGenericRepository.GetSingle(student => student.CourseID == id);
        }


        public void Add(CoursePoco student)
        {
            _eFGenericRepository.Add(student);
        }


        public void Remove(int id)
        {
            CoursePoco course = _eFGenericRepository.GetSingle(student => student.CourseID == id);
            _eFGenericRepository.Remove(course);
        }
    }
}
