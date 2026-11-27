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
        }
    }
}
