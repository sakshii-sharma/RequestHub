using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RequestHub.Domain.Entities;

namespace RequestHub.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets for Entities
        public DbSet<Attachment> Attachments => Set<Attachment>();
        public DbSet<AuditableEntity> AuditableEntities => Set<AuditableEntity>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<AuditLogChange> AuditLogChanges => Set<AuditLogChange>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<RequestComment> RequestComments => Set<RequestComment>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();
        public DbSet<StatusHistory> StatusHistories => Set<StatusHistory>();
        public DbSet<User> Users => Set<User>(); // UserRoles - Join table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}


/*
    NOTE : The constructor receives options, including the connection string, from Dependency Injection. 
           Set<Category>() means "this property is the Categories table." 
           OnModelCreating finds every configuration class in this project and applies it.
*/