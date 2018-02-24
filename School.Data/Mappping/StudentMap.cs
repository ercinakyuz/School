using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entity;

namespace School.Data.Mappping
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.Firstname).IsRequired();
            builder.Property(p => p.Lastname).IsRequired();
            builder.Property(p => p.Number).IsRequired();
        }
    }
}
