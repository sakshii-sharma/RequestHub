using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            // HasConversion<int>() stores the enum as a number. In SSMS, Employee is 1, not the word Employee.
            builder.Property(r => r.Name).HasConversion<int>().IsRequired();
            builder.HasIndex(r => r.Name).IsUnique();
        }
    }
}
