using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using RequestHub.Domain.Entities;


namespace RequestHub.Infrastructure.Persistence.Configurations
{
    public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {
            builder.ToTable("ServiceRequests");

            builder.Property(r => r.ReferenceNo).IsRequired().HasMaxLength(32);
            builder.Property(r => r.Title).IsRequired().HasMaxLength(200);
            builder.Property(r => r.Description).IsRequired().HasMaxLength(4000);
            builder.Property(r => r.Priority).HasConversion<int>();
            builder.Property(r => r.Status).HasConversion<int>();

            
            // IsRowVersion() tells SQL Server to change that token on every update. 
            builder.Property(r => r.RowVersion).IsRowVersion();
            builder.HasIndex(r => r.ReferenceNo).IsUnique();

            builder.HasOne(r => r.Category)
                   .WithMany(c => c.ServiceRequests)
                   .HasForeignKey(r => r.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Requester)
                   .WithMany()
                   .HasForeignKey(r => r.RequesterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Assignee)
                   .WithMany()
                   .HasForeignKey(r => r.AssigneeId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
