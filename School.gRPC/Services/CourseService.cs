using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using School.gRPC.Protos;
using SchoolAPI.Logic;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static School.gRPC.Protos.Course;

namespace School.gRPC.Services
{
    public class CourseService : CourseBase
    {
        private CourseLogic _logic = new CourseLogic(new EFGenericRepository<CoursePoco>());
        public override Task<CourseReply> GetCourse(CourseIDRequest request, ServerCallContext context)
        {
            CoursePoco CoursePoco = _logic.GetSingle(request.CourseID);
            CourseReply CourseReply = new CourseReply()
            {
                CourseID = CoursePoco.CourseID,
                CourseName = CoursePoco.CourseName

            };

            return Task.FromResult(CourseReply);
        }

        public override Task<Courses> GetCourses(Empty request, ServerCallContext context)
        {
            List<CoursePoco> coursePocos = _logic.GetAll().ToList();
            Courses courseCollection = new Courses();
            foreach (CoursePoco coursePoco in coursePocos)
            {
                courseCollection.CouRep.Add(new CourseReply 
                                                { 
                                                    CourseID = coursePoco.CourseID,
                                                    CourseName = coursePoco.CourseName
                                                });
            }
            return Task.FromResult<Courses>(courseCollection);
        }
        public override Task<Empty> AddCourse(CourseReply request, ServerCallContext context)
        {
            CoursePoco CoursePoco = new CoursePoco()
            {
                CourseID = request.CourseID,
                CourseName = request.CourseName
            };
            _logic.Add(CoursePoco);

            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> DeleteCourse(CourseReply request, ServerCallContext context)
        {
            _logic.Remove(request.CourseID);

            return Task.FromResult<Empty>(null);
        }
    }
}

