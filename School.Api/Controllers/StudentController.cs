using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.Manager;

namespace School.Api.Controllers
{
    [Authorize]
    public class StudentController : ApiController
    {
        private static readonly List<Student> StudentList = new List<Student>();
        private readonly StudentManager _studentManager;

        public StudentController()
        {

            _studentManager = new StudentManager();
        }

        [HttpGet]
        public IEnumerable<StudentListDto> Get()
        {
            var currentUser = User;
            var students = _studentManager.GetAll();
            return (students != null && students.Any()) ? students : null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Student Get(Guid id)
        {
            var student = StudentList.Find(x => x.Id == id);
            return student;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = Guid.NewGuid();
                StudentList.Add(student);
                var current = StudentList.Find(x => x.Id == student.Id);
                return Created(string.Empty, current);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody]Student student)
        {
            var current = StudentList.Find(x => x.Id == id);
            if (current == null)
            {
                return NoContent();
            }
            current.Name = student.Name;
            return Ok(current);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var current = StudentList.Find(x => x.Id == id);
            if (current == null)
            {
                return NoContent();
            }
            else
            {
                StudentList.RemoveAll(x => x.Id == id);
                current = StudentList.Find(x => x.Id == id);
                return current == null ? Ok() : new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

        }

        public class Student
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
