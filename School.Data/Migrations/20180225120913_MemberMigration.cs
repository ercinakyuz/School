using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace School.Data.Migrations
{
    public partial class MemberMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Member_Id",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLesson_Lesson_LessonId",
                table: "StudentLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLesson_Student_StudentId",
                table: "StudentLesson");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Member_Id",
                table: "Student",
                column: "Id",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLesson_Lesson_LessonId",
                table: "StudentLesson",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLesson_Student_StudentId",
                table: "StudentLesson",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Member_Id",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLesson_Lesson_LessonId",
                table: "StudentLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLesson_Student_StudentId",
                table: "StudentLesson");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Member_Id",
                table: "Student",
                column: "Id",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLesson_Lesson_LessonId",
                table: "StudentLesson",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLesson_Student_StudentId",
                table: "StudentLesson",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
