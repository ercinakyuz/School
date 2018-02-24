using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entity;

namespace School.Data.Mappping
{
    public class TeacherMap:IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(p => p.Firstname).IsRequired();
            builder.Property(p => p.Lastname).IsRequired();
            builder.Property(p => p.Salary).IsRequired();
        }
    }
}
