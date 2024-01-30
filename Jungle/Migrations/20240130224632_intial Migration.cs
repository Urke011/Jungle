using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jungletribe.Migrations
{
    /// <inheritdoc />
    public partial class intialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travelinfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Traveler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelDestinacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelPeriod = table.Column<int>(type: "int", nullable: false),
                    TravelPrice = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    TravelContinent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travelinfo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travelinfo");
        }
    }
}
