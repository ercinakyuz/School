using System.Collections.Generic;
using System.Linq;
using School.Common.Helper;
using School.Data.Entity;
using School.Data.Repository;

namespace School.Business.Manager
{
    public class StudentManager
    {
        private readonly StudentRepository _studentRepository;
        private readonly MemberRepository _memberRepository;
        public StudentManager()
        {
            _memberRepository = new MemberRepository();
            _studentRepository = new StudentRepository();
        }

        public List<StudentListDto> GetAll()
        {
            var studentList = _studentRepository.GetAllWithMember();
            return studentList.Select(student => new StudentListDto
            {
                Firstname = student.Member.Firstname,
                Number = student.Number,
                Lastname = student.Member.Lastname,
                Email = student.Member.Email
            }).ToList();
        }
        public StudentDetailDto Find(int id)
        {
            StudentDetailDto studentDetail = null;
            var student = _studentRepository.FindWithMember(id);
            if (student != null)
            {
                studentDetail = new StudentDetailDto
                {
                    Id = student.Id,
                    Email = student.Member.Email,
                    Firstname = student.Member.Firstname,
                    Lastname = student.Member.Lastname,
                    Number = student.Member.Student.Number
                };
            }
            return studentDetail;

        }
        public StudentCreatedDto Create(StudentCreateDto dto)
        {
            string password = GenerateHelper.GeneratePassword(8);
            var student = new Member
            {
                Email = dto.Email,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Password = EncryptionHelper.Md5Hash(password),
                Student = new Student
                {
                    Number = GenerateHelper.GenerateNumber(6)
                }
            };
            var member = _memberRepository.Insert(student);
            return new StudentCreatedDto
            {
                Id = student.Id,
                Email = member.Email,
                Firstname = member.Firstname,
                Lastname = member.Lastname,
                Number = member.Student.Number,
                Password = password
            };
        }
        public StudentUpdatedDto Update(StudentUpdateDto dto)
        {
            StudentUpdatedDto updatedDto = null;
            var student = _studentRepository.FindWithMember(dto.Id);
            if (student != null)
            {
                student.Member.Email = dto.Email;
                student.Member.Firstname = dto.Firstname;
                student.Member.Lastname = dto.Lastname;
                if (!string.IsNullOrEmpty(dto.Password))
                {
                    student.Member.Password = EncryptionHelper.Md5Hash(dto.Password);
                }
                var updatedMember = _studentRepository.Update(student);
                updatedDto = new StudentUpdatedDto
                {
                    Email = updatedMember.Member.Email,
                    Firstname = updatedMember.Member.Firstname,
                    Lastname = updatedMember.Member.Lastname,
                    Id = updatedMember.Id,
                    Number = updatedMember.Number,
                    Password = dto.Password,
                };
            }

            return updatedDto;
        }

        public StudentDeletedDto Delete(int id)
        {
            StudentDeletedDto studentDeleted = null;
            var member = _memberRepository.FindWithStudent(id);
            if (member != null && member.Student != null)
            {
                var deletedMember = _memberRepository.Delete(member);
                studentDeleted = new StudentDeletedDto
                {
                    Firstname = deletedMember.Firstname,
                    Lastname = deletedMember.Lastname,
                    Email = deletedMember.Email,
                    Number = deletedMember.Student.Number,
                    Id = deletedMember.Id
                };
            }
            return studentDeleted;
        }

    }

    public class StudentCreateDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }

    public class StudentListDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
    public class StudentDetailDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
    public class StudentCreatedDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
    public class StudentUpdateDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class StudentDeletedDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }

    }
    public class StudentUpdatedDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
}
