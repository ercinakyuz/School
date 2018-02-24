using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entity;

namespace School.Data.Mappping
{
    public class StandardMap : IEntityTypeConfiguration<StandardEntity>
    {
        public void Configure(EntityTypeBuilder<StandardEntity> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
