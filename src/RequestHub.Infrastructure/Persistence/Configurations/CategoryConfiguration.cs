using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.SlaHours).IsRequired();

            // The unique index means one department cannot have two categories with the same name.
            builder.HasIndex(c => new { c.DepartmentId, c.Name }).IsUnique();


            // HasOne / WithMany is the department relationship.
            // Restrict means SQL Server refuses to delete a department that still has categories.
            // DepartmentId is the foreign key in the Category table that points to the Department table.
            // Since FK is in Category (entity class / table), we configure it in CategoryConfiguration.
            builder.HasOne(c=> c.Department)
                   .WithMany(d => d.Categories)
                   .HasForeignKey(c => c.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
