using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations
{
    public class RequestCommentConfiguration : IEntityTypeConfiguration<RequestComment>
    {
        public void Configure(EntityTypeBuilder<RequestComment> builder)
        {
            builder.ToTable("RequestComments");
            builder.Property(c => c.Body).HasMaxLength(4000).IsRequired();


            // DeleteBehaviour Cascade for ServiceRequestId, Restrict for AuthorId
            // This means that if a ServiceRequest is deleted, all associated RequestComments will also be deleted.
            // However, if a User (Author) is deleted, the associated RequestComments will not be deleted, and the AuthorId will remain in the database.

            builder.HasOne(rc => rc.ServiceRequest)
                   .WithMany(sr => sr.Comments)
                   .HasForeignKey(rc => rc.ServiceRequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rc => rc.Author)
                   .WithMany()
                   .HasForeignKey(rc => rc.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
