using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldResortServer.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PassportSeries = table.Column<int>(type: "int", nullable: false),
                    PassportNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    img = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PartWorlds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartWorlds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TypeRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PartWorldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                    table.ForeignKey(
                        name: "FK_Countries_PartWorlds_PartWorldId",
                        column: x => x.PartWorldId,
                        principalTable: "PartWorlds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartWorldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Climate = table.Column<bool>(type: "bit", nullable: false),
                    TherapeuticMud = table.Column<bool>(type: "bit", nullable: false),
                    MineralWater = table.Column<bool>(type: "bit", nullable: false),
                    img = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e498232-51ad-4e77-bcea-2abd41dc1ceb", "dc463120-d5cb-4629-91ad-05efa8c09e4d", "Admin", "ADMIN" },
                    { "f4268878-1841-4599-aab7-afc0c9d816c1", "f048d8dd-f1d5-4ecd-a743-56073a890bce", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "PartWorlds",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120"), "Европа" },
                    { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121"), "Азия" },
                    { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122"), "Африка" },
                    { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47123"), "Австралия" },
                    { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124"), "Америка" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "Name", "PartWorldId" },
                values: new object[,]
                {
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de000"), "Россия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de001"), "Китай", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de002"), "Индия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de003"), "Италия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de004"), "Испания", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de005"), "Канада", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de006"), "США", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de007"), "Бразилия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de008"), "Австралия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47123") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de009"), "Португалия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de010"), "Грузия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de011"), "Англия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de012"), "Япония", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de013"), "Германия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de014"), "Армения", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de015"), "Франция", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de016"), "Чили", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de017"), "Египет", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de018"), "Тунис", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de019"), "Марокко", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de020"), "ЮАР", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de021"), "Индонезия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de022"), "ОАЭ", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_PartWorldId",
                table: "Countries",
                column: "PartWorldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "TypeRooms");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "PartWorlds");
        }
    }
}
