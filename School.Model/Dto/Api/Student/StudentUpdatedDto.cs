﻿namespace School.Model.Dto.Api.Student
{
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