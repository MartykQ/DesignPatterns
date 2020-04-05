using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    XPosition = table.Column<double>(nullable: false),
                    YPosition = table.Column<double>(nullable: false),
                    CurrentDistance = table.Column<double>(nullable: false),
                    TotalDistance = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(nullable: false),
                    LicenseNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    RentalID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.RentalID);
                });

            migrationBuilder.CreateTable(
                name: "RentalViews",
                columns: table => new
                {
                    RentalId = table.Column<int>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    StopDateTime = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    StartXPostion = table.Column<double>(nullable: false),
                    StartYPosition = table.Column<double>(nullable: false),
                    StopXPosition = table.Column<double>(nullable: false),
                    StopYPosition = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalViews", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_RentalViews_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalViews_DriverId",
                table: "RentalViews",
                column: "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "RentalViews");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
