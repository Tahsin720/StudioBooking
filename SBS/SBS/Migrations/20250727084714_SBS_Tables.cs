using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SBS.Migrations
{
    /// <inheritdoc />
    public partial class SBS_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RadiusKm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudioId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSlot = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "studios",
                columns: new[] { "Id", "Amenities", "Area", "Latitude", "Location", "Longitude", "Name", "PricePerHour", "RadiusKm", "Rating", "Type" },
                values: new object[,]
                {
                    { 1, "Microphones, Soundproofing", "Central", 40.7128m, "Downtown, City A", -74.0060m, "Studio A", 50.00m, 10, 4.5m, "Recording" },
                    { 2, "Lighting, Backdrops", "Western", 34.0522m, "Westside, City B", -118.2437m, "Studio B", 30.00m, 15, 4.0m, "Photography" },
                    { 3, "Cameras, Green Screen", "Eastern", 41.8781m, "Eastside, City A", -87.6298m, "Studio C", 70.00m, 20, 4.8m, "Video" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Date", "Email", "StudioId", "TimeSlot", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@email.com", 1, "10:00-12:00", "John Doe" },
                    { 2, new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@email.com", 2, "14:00-16:00", "Jane Smith" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StudioId",
                table: "Bookings",
                column: "StudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "studios");
        }
    }
}
