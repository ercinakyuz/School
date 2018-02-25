﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using School.Common.Enum;
using School.Data.Context;
using System;

namespace School.Data.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("School.Data.Entity.Admin", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("School.Data.Entity.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("School.Data.Entity.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<DateTime>("EndAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartAt");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("School.Data.Entity.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("School.Data.Entity.Student", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Number")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("School.Data.Entity.StudentLesson", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("LessonId");

                    b.HasKey("StudentId", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("StudentLesson");
                });

            modelBuilder.Entity("School.Data.Entity.Teacher", b =>
                {
                    b.Property<int>("Id");

                    b.Property<decimal>("Salary");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("School.Data.Entity.Admin", b =>
                {
                    b.HasOne("School.Data.Entity.Member", "Member")
                        .WithOne("Admin")
                        .HasForeignKey("School.Data.Entity.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("School.Data.Entity.Lesson", b =>
                {
                    b.HasOne("School.Data.Entity.Classroom", "Classroom")
                        .WithMany("Lessons")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("School.Data.Entity.Teacher", "Teacher")
                        .WithMany("Lessons")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("School.Data.Entity.Student", b =>
                {
                    b.HasOne("School.Data.Entity.Member", "Member")
                        .WithOne("Student")
                        .HasForeignKey("School.Data.Entity.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("School.Data.Entity.StudentLesson", b =>
                {
                    b.HasOne("School.Data.Entity.Lesson", "Lesson")
                        .WithMany("Students")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("School.Data.Entity.Student", "Student")
                        .WithMany("Lessons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("School.Data.Entity.Teacher", b =>
                {
                    b.HasOne("School.Data.Entity.Member", "Member")
                        .WithOne("Teacher")
                        .HasForeignKey("School.Data.Entity.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
