using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01cf55b0-aa14-4cec-a2f1-0a938cf6f8c3", "4", "User", "User" },
                    { "086234d9-6c37-4423-8e18-fdb1493c3dd8", "1", "SuperAdmin", "SuperAdmin" },
                    { "3e496beb-f7fb-4834-9160-7b8b644a30ea", "3", "SuperUser", "SuperUser" },
                    { "c2000fc0-2a44-403f-9682-d8bc1060d1b0", "2", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01cf55b0-aa14-4cec-a2f1-0a938cf6f8c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "086234d9-6c37-4423-8e18-fdb1493c3dd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e496beb-f7fb-4834-9160-7b8b644a30ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2000fc0-2a44-403f-9682-d8bc1060d1b0");
        }
    }
}
