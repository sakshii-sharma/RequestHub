using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestHub.Domain.Entities;
using RequestHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

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

            // seed data for roles
            builder.HasData(
                new Role { Id = 1, Name = AppRole.Employee, Users = null! },
                new Role { Id = 2, Name = AppRole.Agent, Users = null! },
                new Role { Id = 3, Name = AppRole.Manager, Users = null! },
                new Role { Id = 4, Name = AppRole.Admin, Users = null! }
            );
        }
    }
}
