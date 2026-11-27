using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(u => u.FullName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the many-to-many relationship between User and Role
            // a join entity called UserRole
            // UserRoles is the extra table for "one user, many roles."
            // Email is unique so two accounts cannot share it.
            builder.HasMany(u => u.Roles)
                   .WithMany(r => r.Users)
                   .UsingEntity(join => join.ToTable("UserRoles"));
        }
    }
}
