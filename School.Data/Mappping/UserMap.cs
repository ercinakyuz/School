using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entity;

namespace School.Data.Mappping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.HasOne(p => p.Student).WithOne(p => p.User).HasForeignKey<Student>(fk => fk.Id);
        }
    }
}
