using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

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
    }
}
