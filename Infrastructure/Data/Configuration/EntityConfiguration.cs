using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(255);
            builder.HasOne(r => r.RelatedEntity).WithMany()
                .HasForeignKey(r => r.RelatedEntityId);
        }
    }
}