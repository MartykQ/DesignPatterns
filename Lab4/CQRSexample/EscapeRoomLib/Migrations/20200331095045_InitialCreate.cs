using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EscapeRoom_CQRS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.CheckConstraint("CK_Players_Status_Enum_Constraint", "[Status] IN(0, 1)");
                });

            migrationBuilder.CreateTable(
                name: "ReservationViews",
                columns: table => new
                {
                    ReservationId = table.Column<Guid>(nullable: false),
                    ReservationDateTime = table.Column<DateTime>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false),
                    PlayerName = table.Column<string>(nullable: true),
                    RoomId = table.Column<Guid>(nullable: false),
                    RoomName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationViews", x => x.ReservationId);
                    table.CheckConstraint("CK_ReservationViews_Status_Enum_Constraint", "[Status] IN(0, 1, 3, 4)");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.CheckConstraint("CK_Rooms_Level_Enum_Constraint", "[Level] IN(0, 1, 2)");
                    table.CheckConstraint("CK_Rooms_Status_Enum_Constraint", "[Status] IN(0, 1, 2)");
                });

            migrationBuilder.CreateTable(
                name: "VisitViews",
                columns: table => new
                {
                    VisitId = table.Column<Guid>(nullable: false),
                    EnterDateTime = table.Column<DateTime>(nullable: false),
                    ExitDateTime = table.Column<DateTime>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false),
                    PlayerName = table.Column<string>(nullable: true),
                    RoomId = table.Column<Guid>(nullable: false),
                    RoomName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitViews", x => x.VisitId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<Guid>(nullable: false),
                    ReservationDateTime = table.Column<DateTime>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    VisitId = table.Column<Guid>(nullable: true),
                    PlayerId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.CheckConstraint("CK_Reservations_Status_Enum_Constraint", "[Status] IN(0, 1, 3, 4)");
                    table.ForeignKey(
                        name: "FK_Reservations_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitId = table.Column<Guid>(nullable: false),
                    EnterDateTime = table.Column<DateTime>(nullable: false),
                    ExitDateTime = table.Column<DateTime>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    ReservationId = table.Column<Guid>(nullable: true),
                    PlayerId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visits_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PlayerId",
                table: "Reservations",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VisitId",
                table: "Reservations",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PlayerId",
                table: "Visits",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ReservationId",
                table: "Visits",
                column: "ReservationId",
                unique: true,
                filter: "[ReservationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_RoomId",
                table: "Visits",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Visits_VisitId",
                table: "Reservations",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Players_PlayerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Players_PlayerId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Rooms_RoomId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Visits_VisitId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "ReservationViews");

            migrationBuilder.DropTable(
                name: "VisitViews");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
