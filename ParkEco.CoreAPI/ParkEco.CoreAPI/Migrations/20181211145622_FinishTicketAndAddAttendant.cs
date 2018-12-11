using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkEco.CoreAPI.Migrations
{
    public partial class FinishTicketAndAddAttendant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParkingLotAttendantId",
                table: "Tickets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "ParkingLots",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "ParkingLots",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ParkingLotAttendant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLotAttendant", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ParkingLotAttendantId",
                table: "Tickets",
                column: "ParkingLotAttendantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ParkingLotAttendant_ParkingLotAttendantId",
                table: "Tickets",
                column: "ParkingLotAttendantId",
                principalTable: "ParkingLotAttendant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ParkingLotAttendant_ParkingLotAttendantId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "ParkingLotAttendant");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ParkingLotAttendantId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ParkingLotAttendantId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "ParkingLots");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "ParkingLots");
        }
    }
}
