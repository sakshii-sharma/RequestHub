using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("AuditLogs");
        builder.Property(a => a.RecordId).HasMaxLength(50).IsRequired();
        builder.Property(a => a.Action).HasConversion<int>();
        builder.Property(a => a.UserEmail).HasMaxLength(256);

        builder.HasOne(a => a.AuditableEntity)
               .WithMany()
               .HasForeignKey(a => a.AuditableEntityId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}