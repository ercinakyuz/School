using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entity;

namespace School.Data.Mappping
{
    public class StudentLessonMap : IEntityTypeConfiguration<StudentLesson>
    {
        public void Configure(EntityTypeBuilder<StudentLesson> builder)
        {
            builder.HasKey(ck => new { ck.StudentId, ck.LessonId });
            builder.HasOne(p => p.Student).WithMany(p => p.Lessons).HasForeignKey(p => p.StudentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Lesson).WithMany(p => p.Students).HasForeignKey(p => p.LessonId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
