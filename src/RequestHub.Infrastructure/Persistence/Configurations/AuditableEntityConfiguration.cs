using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations
{
    public class AuditableEntityConfiguration : IEntityTypeConfiguration<AuditableEntity>
    {
        public void Configure(EntityTypeBuilder<AuditableEntity> builder)
        {
            builder.ToTable("AuditableEntities");
            builder.Property(a => a.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(a => a.Name).IsUnique();

            // seed data for auditable entities
            builder.HasData(
                new AuditableEntity { Id = 1, Name = "ServiceRequest", IsEnabled = true, CreatedAt = SeedData.CreatedAt, UpdatedAt = SeedData.CreatedAt, Fields = null! },
                new AuditableEntity { Id = 2, Name = "User", IsEnabled = true, CreatedAt = SeedData.CreatedAt, UpdatedAt = SeedData.CreatedAt, Fields = null! },
                new AuditableEntity { Id = 3, Name = "Category", IsEnabled = true, CreatedAt = SeedData.CreatedAt, UpdatedAt = SeedData.CreatedAt, Fields = null! }
            );
        }
    }
}
