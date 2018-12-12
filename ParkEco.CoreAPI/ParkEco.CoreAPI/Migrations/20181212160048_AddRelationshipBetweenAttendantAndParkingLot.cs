using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkEco.CoreAPI.Migrations
{
    public partial class AddRelationshipBetweenAttendantAndParkingLot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendantAssignment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParkingLotId = table.Column<Guid>(nullable: false),
                    ParkingLotAttendantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendantAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendantAssignment_ParkingLotAttendants_ParkingLotAttendantId",
                        column: x => x.ParkingLotAttendantId,
                        principalTable: "ParkingLotAttendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendantAssignment_ParkingLots_ParkingLotId",
                        column: x => x.ParkingLotId,
                        principalTable: "ParkingLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendantAssignment_ParkingLotAttendantId",
                table: "AttendantAssignment",
                column: "ParkingLotAttendantId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendantAssignment_ParkingLotId",
                table: "AttendantAssignment",
                column: "ParkingLotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendantAssignment");
        }
    }
}
