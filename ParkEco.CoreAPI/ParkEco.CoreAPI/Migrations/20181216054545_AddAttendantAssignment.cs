using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkEco.CoreAPI.Migrations
{
    public partial class AddAttendantAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendantAssignment_ParkingLotAttendants_ParkingLotAttendantId",
                table: "AttendantAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendantAssignment_ParkingLots_ParkingLotId",
                table: "AttendantAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendantAssignment",
                table: "AttendantAssignment");

            migrationBuilder.RenameTable(
                name: "AttendantAssignment",
                newName: "AttendantAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_AttendantAssignment_ParkingLotId",
                table: "AttendantAssignments",
                newName: "IX_AttendantAssignments_ParkingLotId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendantAssignment_ParkingLotAttendantId",
                table: "AttendantAssignments",
                newName: "IX_AttendantAssignments_ParkingLotAttendantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendantAssignments",
                table: "AttendantAssignments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendantAssignments_ParkingLotAttendants_ParkingLotAttendantId",
                table: "AttendantAssignments",
                column: "ParkingLotAttendantId",
                principalTable: "ParkingLotAttendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendantAssignments_ParkingLots_ParkingLotId",
                table: "AttendantAssignments",
                column: "ParkingLotId",
                principalTable: "ParkingLots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendantAssignments_ParkingLotAttendants_ParkingLotAttendantId",
                table: "AttendantAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendantAssignments_ParkingLots_ParkingLotId",
                table: "AttendantAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendantAssignments",
                table: "AttendantAssignments");

            migrationBuilder.RenameTable(
                name: "AttendantAssignments",
                newName: "AttendantAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_AttendantAssignments_ParkingLotId",
                table: "AttendantAssignment",
                newName: "IX_AttendantAssignment_ParkingLotId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendantAssignments_ParkingLotAttendantId",
                table: "AttendantAssignment",
                newName: "IX_AttendantAssignment_ParkingLotAttendantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendantAssignment",
                table: "AttendantAssignment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendantAssignment_ParkingLotAttendants_ParkingLotAttendantId",
                table: "AttendantAssignment",
                column: "ParkingLotAttendantId",
                principalTable: "ParkingLotAttendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendantAssignment_ParkingLots_ParkingLotId",
                table: "AttendantAssignment",
                column: "ParkingLotId",
                principalTable: "ParkingLots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
