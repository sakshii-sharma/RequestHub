using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RequestHub.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedReferenceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuditableEntities",
                columns: new[] { "Id", "CreatedAt", "IsEnabled", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, "ServiceRequest", new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, "User", new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, "Category", new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, "Information Technology", new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, "Human Resources", new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, "Finance", new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, "Facilities", new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "IsActive", "Name", "RequiresApproval", "SlaHours", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), 1, true, "Laptop request", false, 48, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), 1, true, "Access request", true, 24, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), 2, true, "Onboarding", true, 72, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), 4, true, "Desk repair", false, 48, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "Email", "FailedLoginCount", "FullName", "IsActive", "LockoutEnd", "PasswordHash", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), 1, "admin@requesthub.local", 0, "System Admin", true, null, "temporary-hash-replaced-on-day-2", new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { 4, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuditableEntities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuditableEntities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuditableEntities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
