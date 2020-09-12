using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using School.gRPC.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static School.gRPC.Protos.Student;
using SchoolAPI.Controllers;

namespace School.gRPC.Services
{
    public class StudentService : StudentBase
    {
        private StudentController _studentController = new StudentController();
        public override Task<StudentReply> GetStudent(StudentIDRequest request, ServerCallContext context)
        {
            SchoolAPI.Models.Student studentPoco =  _studentController.Get(request.StudentID);
            StudentReply studentReply =  new StudentReply()
            {
                StudentID = studentPoco.StudentID,
                Name = studentPoco.Name

            };

            return Task.FromResult(studentReply);
        }

        /*public override Task<Students> GetStudents(Empty request, ServerCallContext context)
        {
            return Task.FromResult<Empty>(null);
        }*/
        public override Task<Empty> AddStudent(StudentReply request, ServerCallContext context)
        {
            SchoolAPI.Models.Student studentPoco = new SchoolAPI.Models.Student()
            {
                StudentID = request.StudentID,
                Name = request.Name
            };
            _studentController.Post(studentPoco);

            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> DeleteStudent(StudentReply request, ServerCallContext context)
        {
            _studentController.Delete(request.StudentID);

            return Task.FromResult<Empty>(null);
        }
    }
}
