using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations;

public class AuditableFieldConfiguration : IEntityTypeConfiguration<AuditableField>
{
    public void Configure(EntityTypeBuilder<AuditableField> builder)
    {
        builder.ToTable("AuditableFields");
        builder.Property(f => f.FieldName).HasMaxLength(100).IsRequired();
        builder.HasIndex(f => new { f.AuditableEntityId, f.FieldName }).IsUnique();

        builder.HasOne(f => f.AuditableEntity)
               .WithMany(e => e.Fields)
               .HasForeignKey(f => f.AuditableEntityId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}