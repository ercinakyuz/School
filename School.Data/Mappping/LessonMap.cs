using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entity;

namespace School.Data.Mappping
{
    public class LessonMap: IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.StartAt).IsRequired();
            builder.Property(p => p.EndAt).IsRequired();
            builder.HasOne(p => p.Classroom).WithMany(p => p.Lessons).HasForeignKey(p => p.ClassId);
            builder.HasOne(p => p.Teacher).WithMany(p => p.Lessons).HasForeignKey(p => p.TeacherId);
        }
    }
}
