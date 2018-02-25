using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entity;

namespace School.Data.Mappping
{
    public class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.HasOne(p => p.Student).WithOne(p => p.Member).HasForeignKey<Student>(fk => fk.Id);
            builder.HasOne(p => p.Teacher).WithOne(p => p.Member).HasForeignKey<Teacher>(fk => fk.Id);
            builder.HasOne(p => p.Admin).WithOne(p => p.Member).HasForeignKey<Admin>(fk => fk.Id);
        }
    }
}
