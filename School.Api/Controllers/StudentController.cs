using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Business.Manager;
using School.Model.Dto.Api.Student;

namespace School.Api.Controllers
{
    [Authorize]
    public class StudentController : ApiController
    {
        private readonly StudentManager _studentManager;

        public StudentController()
        {
            _studentManager = new StudentManager();
        }

        [HttpGet]
        public IEnumerable<StudentListDto> Get()
        {
            var students = _studentManager.GetAll();
            return students;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public StudentDetailDto Get(int id)
        {
            var student = _studentManager.Find(id);
            if (student == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            return student;
        }

        [HttpPost]
        public ActionResult Post([FromBody]StudentCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var student = _studentManager.Create(dto);
                return Created(string.Empty, student);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public StudentUpdatedDto Put([FromBody]StudentUpdateDto dto)
        {
            StudentUpdatedDto updatedStudent = null;
            if (ModelState.IsValid)
            {
                updatedStudent = _studentManager.Update(dto);
                if (updatedStudent == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                }

            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return updatedStudent;
        }

        [HttpDelete("{id}")]
        public StudentDeletedDto Delete(int id)
        {
            var deletedStudent = _studentManager.Delete(id);
            if (deletedStudent == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.NoContent;
            }
            return deletedStudent;
        }
    }
}
