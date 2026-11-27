using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations;

public class AuditLogChangeConfiguration : IEntityTypeConfiguration<AuditLogChange>
{
    public void Configure(EntityTypeBuilder<AuditLogChange> builder)
    {
        builder.ToTable("AuditLogChanges");
        builder.Property(c => c.FieldName).HasMaxLength(100).IsRequired();

        builder.HasOne(c => c.AuditLog)
               .WithMany(a => a.Changes)
               .HasForeignKey(c => c.AuditLogId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}