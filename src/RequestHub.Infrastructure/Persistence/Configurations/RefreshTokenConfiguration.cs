using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Infrastructure.Persistence.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens");

            builder.Property(t => t.TokenHash).HasMaxLength(500).IsRequired();
            builder.Property(t => t.ReplacedByTokenHash).HasMaxLength(500);
            builder.HasIndex(t => t.TokenHash).IsUnique();

            // Configuring the relationship between RefreshToken and User
            // A RefreshToken belongs to one User, and a User can have many RefreshTokens
            // The foreign key is UserId in the RefreshToken entity
            // The OnDelete(DeleteBehavior.Cascade) ensures that when a User is deleted, all associated RefreshTokens are also deleted
            builder.HasOne(t => t.User)
                   .WithMany(u => u.RefreshTokens)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.Cascade);   

        }
    }
}
