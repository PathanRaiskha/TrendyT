using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrendyT.Data.Migrations
{
    /// <inheritdoc />
    public partial class rolechnaged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e117e76-8d18-4987-b2ce-9f7161c24670");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa377bbe-e160-4709-8165-4f1d7b25eff9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01afea14-7cce-4e69-a35b-cbda4656e8ba", "2", "Customer", "Customer" },
                    { "0e9dbee9-1540-4142-a0ad-340b88de2a0d", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01afea14-7cce-4e69-a35b-cbda4656e8ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e9dbee9-1540-4142-a0ad-340b88de2a0d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e117e76-8d18-4987-b2ce-9f7161c24670", "2", "User", "User" },
                    { "fa377bbe-e160-4709-8165-4f1d7b25eff9", "1", "Admin", "Admin" }
                });
        }
    }
}
