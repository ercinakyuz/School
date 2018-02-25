﻿using System.Collections.Generic;
using System.Linq;
using School.Data.Entity;
using School.Data.Repository;

namespace School.Business.Manager
{
    public class StudentManager
    {
        private readonly BaseRepository<Student> _studentRepository;
        public StudentManager()
        {
            _studentRepository = RepositoryFactory.Create<Student>();
        }

        public IEnumerable<StudentListDto> GetAll()
        {
            var studentList = _studentRepository.GetAll();
            return studentList.Select(student=>new StudentListDto
            {
                Firstname = student.Member.Firstname,
                Number = student.Number,
                Lastname = student.Member.Lastname,
                Email = student.Member.Email
            });
        }
    }

    public class StudentListDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
}
