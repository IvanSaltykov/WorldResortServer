using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldResortServer.Migrations
{
    /// <inheritdoc />
    public partial class AddTableFavouriteHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e498232-51ad-4e77-bcea-2abd41dc1ceb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4268878-1841-4599-aab7-afc0c9d816c1");

            migrationBuilder.CreateTable(
                name: "FavoriteHotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteHotels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6448c549-d552-4bf2-9c5e-3e447256558e", "2f493472-d67d-46ea-abb5-8541c1e9a7ee", "Admin", "ADMIN" },
                    { "c42d3b76-1be1-4869-b4df-5a12352ce673", "57348fdf-02fb-4711-b66e-be4e1a317b30", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteHotels");

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
                    { "4e498232-51ad-4e77-bcea-2abd41dc1ceb", "dc463120-d5cb-4629-91ad-05efa8c09e4d", "Admin", "ADMIN" },
                    { "f4268878-1841-4599-aab7-afc0c9d816c1", "f048d8dd-f1d5-4ecd-a743-56073a890bce", "User", "USER" }
                });
        }
    }
}
