using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldResortServer.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6448c549-d552-4bf2-9c5e-3e447256558e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c42d3b76-1be1-4869-b4df-5a12352ce673");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "81a341b9-2ceb-48d1-9c5e-4829061ebaa2", "be2f2dab-a22c-461f-96c7-520db9ae3b45", "Admin", "ADMIN" },
                    { "8cb0aa55-f6c4-454c-93d1-5b32eaac35f1", "a68be5fa-72a3-447d-bbb7-d595728e28cd", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81a341b9-2ceb-48d1-9c5e-4829061ebaa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cb0aa55-f6c4-454c-93d1-5b32eaac35f1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6448c549-d552-4bf2-9c5e-3e447256558e", "2f493472-d67d-46ea-abb5-8541c1e9a7ee", "Admin", "ADMIN" },
                    { "c42d3b76-1be1-4869-b4df-5a12352ce673", "57348fdf-02fb-4711-b66e-be4e1a317b30", "User", "USER" }
                });
        }
    }
}
