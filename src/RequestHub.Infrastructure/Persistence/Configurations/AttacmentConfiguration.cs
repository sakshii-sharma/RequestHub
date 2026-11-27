using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("Attachments");
            builder.Property(a => a.FileName).HasMaxLength(260).IsRequired();
            builder.Property(a => a.ContentType).HasMaxLength(100).IsRequired();
            builder.Property(a => a.BlobName).HasMaxLength(500).IsRequired();
            builder.HasIndex(a => a.BlobName).IsUnique();

            builder.HasOne(a => a.ServiceRequest)
                   .WithMany(r => r.Attachments)
                   .HasForeignKey(a => a.ServiceRequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.UploadedByUser)
                   .WithMany()
                   .HasForeignKey(a => a.UploadedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
