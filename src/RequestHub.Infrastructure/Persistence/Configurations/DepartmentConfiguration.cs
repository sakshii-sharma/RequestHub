using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.Property(d => d.Name).HasMaxLength(100).IsRequired();

            builder.HasIndex(d => d.Name).IsUnique();

            // seed data for departments
            builder.HasData(
                new Department { Id = 1, Name = "Information Technology", IsActive = true, CreatedAt = SeedData.CreatedAt, UpdatedAt = SeedData.CreatedAt, Users = null!, Categories = null! },
                new Department { Id = 2, Name = "Human Resources", IsActive = true, CreatedAt = SeedData.CreatedAt, UpdatedAt = SeedData.CreatedAt, Users = null!, Categories = null! },
                new Department { Id = 3, Name = "Finance", IsActive = true, CreatedAt = SeedData.CreatedAt, UpdatedAt = SeedData.CreatedAt, Users = null!, Categories = null! },
                new Department { Id = 4, Name = "Facilities", IsActive = true, CreatedAt = SeedData.CreatedAt, UpdatedAt = SeedData.CreatedAt, Users = null!, Categories = null! }
            );
        }
        
    }
}
