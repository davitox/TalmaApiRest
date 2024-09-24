using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Talma.Core.Entities;
using Talma.Core.Interfaces;
using Talma.Core.Models;

namespace Talma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository studentRepository;

        public StudentController(IStudentRepository _studentRepository)
        {
            this.studentRepository = _studentRepository;
        }

        [HttpGet("ListStudents")]
        public Response ListStudents()
        {
            var result = this.studentRepository.ListStudents();
            return result;
        }

        [HttpPost("GetStudent")]
        public Response GetStudent(StudentByIdRequest obj)
        {
            var result = this.studentRepository.GetStudent(obj);
            return result;
        }

        [HttpPost("RegStudent")]
        public Response RegStudent(StudentCreateRequest obj)
        {
            var result = this.studentRepository.RegStudent(obj);
            return result;
        }

        [HttpPost("UpdStudent")]
        public Response UpdStudent(StudentUpdateRequest obj)
        {
            var result = this.studentRepository.UpdStudent(obj);
            return result;
        }

        [HttpPost("DelStudent")]
        public Response DelStudent(StudentByIdRequest obj)
        {
            var result = this.studentRepository.DelStudent(obj);
            return result;
        }
    }
}
