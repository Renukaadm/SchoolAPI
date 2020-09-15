using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using School.gRPC.Protos;
using SchoolAPI.Logic;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static School.gRPC.Protos.StudentCourse;

namespace School.gRPC.Services
{
    public class StudentCourseService : StudentCourseBase
    {
        private StudentCourseLogic _logic = new StudentCourseLogic(new EFGenericRepository<StudentCoursePoco>());
        public override Task<StudentCourseReply> GetStudentCourse(StudentCourseIDRequest request, ServerCallContext context)
        {
            StudentCoursePoco StudentCoursePoco = _logic.GetSingle(request.StudentCourseID);
            StudentCourseReply StudentCourseReply = new StudentCourseReply()
            {
                StudentCourseID = StudentCoursePoco.StudentCourseID,
                StudentID = StudentCoursePoco.StudentID,
                CourseID = StudentCoursePoco.CourseID
            };

            return Task.FromResult(StudentCourseReply);
        }

        /*public override Task<StudentCourses> GetStudentCourses(Empty request, ServerCallContext context)
        {
            return Task.FromResult<Empty>(null);
        }*/
        public override Task<Empty> AddStudentCourse(StudentCourseReply request, ServerCallContext context)
        {
            StudentCoursePoco StudentCoursePoco = new StudentCoursePoco()
            {
                StudentCourseID = request.StudentCourseID,
                StudentID = request.StudentID,
                CourseID = request.CourseID
            };
            _logic.Add(StudentCoursePoco);

            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> DeleteStudentCourse(StudentCourseReply request, ServerCallContext context)
        {
            _logic.Remove(request.StudentCourseID);

            return Task.FromResult<Empty>(null);
        }
    }
}

