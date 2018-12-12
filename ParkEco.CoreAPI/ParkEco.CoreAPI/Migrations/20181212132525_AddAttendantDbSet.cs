using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkEco.CoreAPI.Migrations
{
    public partial class AddAttendantDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ParkingLotAttendant_ParkingLotAttendantId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingLotAttendant",
                table: "ParkingLotAttendant");

            migrationBuilder.RenameTable(
                name: "ParkingLotAttendant",
                newName: "ParkingLotAttendants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingLotAttendants",
                table: "ParkingLotAttendants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ParkingLotAttendants_ParkingLotAttendantId",
                table: "Tickets",
                column: "ParkingLotAttendantId",
                principalTable: "ParkingLotAttendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ParkingLotAttendants_ParkingLotAttendantId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingLotAttendants",
                table: "ParkingLotAttendants");

            migrationBuilder.RenameTable(
                name: "ParkingLotAttendants",
                newName: "ParkingLotAttendant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingLotAttendant",
                table: "ParkingLotAttendant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ParkingLotAttendant_ParkingLotAttendantId",
                table: "Tickets",
                column: "ParkingLotAttendantId",
                principalTable: "ParkingLotAttendant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
