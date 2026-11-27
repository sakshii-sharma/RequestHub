using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations
{
    public class StatusHistoryConfiguration : IEntityTypeConfiguration<StatusHistory>
    {
        public void Configure(EntityTypeBuilder<StatusHistory> builder)
        {
            builder.ToTable("StatusHistories");
            builder.Property(s => s.FromStatus).HasConversion<int>();
            builder.Property(s => s.ToStatus).HasConversion<int>().IsRequired();
            builder.Property(s => s.Comment).HasMaxLength(1000);

            builder.HasOne(s => s.ServiceRequest)
                .WithMany(r => r.StatusHistories)
                .HasForeignKey(s => s.ServiceRequestId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(s => s.ChangedByUser)
                .WithMany()
                .HasForeignKey(s => s.ChangedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
