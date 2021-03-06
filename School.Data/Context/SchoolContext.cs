﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using School.Common.Enum;
using School.Common.Helper;
using School.Data.Entity;
using School.Data.Mappping;
using School.Data.Repository;

namespace School.Data.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {
            #region Default Admin
            if (!Member.Any())
            {
                Member.Add(new Member
                {
                    Email = "b.ercin.akyuz@gmail.com",
                    Password = EncryptionHelper.Md5Hash("123456"),
                    Firstname = "Erçin",
                    Lastname = "Akyüz",
                    Admin = new Admin
                    {
                        Role = RoleType.Super
                    }

                });
                SaveChanges();
            } 
            #endregion
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<StudentLesson> StudentLesson { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Member> Member { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = @"Server=(localdb)\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;ConnectRetryCount=0";
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new BaseEntityMap());
            //modelBuilder.ApplyConfiguration(new StandardMap());


            modelBuilder.ApplyConfiguration(new ClassroomMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new LessonMap());
            modelBuilder.ApplyConfiguration(new StudentLessonMap());
            modelBuilder.ApplyConfiguration(new TeacherMap());
            modelBuilder.ApplyConfiguration(new MemberMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
