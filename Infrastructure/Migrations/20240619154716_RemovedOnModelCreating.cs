using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44e23f35-0d09-467d-bf64-22deea2fbb40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e29ec8-9f5b-4c98-a85c-d16cb1a03748");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c1647b8-d913-4e9a-b28a-dd0860f59856");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1628089-9f29-4bb3-a458-c73171195be4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44e23f35-0d09-467d-bf64-22deea2fbb40", "2", "Admin", "Admin" },
                    { "46e29ec8-9f5b-4c98-a85c-d16cb1a03748", "4", "User", "User" },
                    { "5c1647b8-d913-4e9a-b28a-dd0860f59856", "3", "SuperUser", "SuperUser" },
                    { "f1628089-9f29-4bb3-a458-c73171195be4", "1", "SuperAdmin", "SuperAdmin" }
                });
        }
    }
}
