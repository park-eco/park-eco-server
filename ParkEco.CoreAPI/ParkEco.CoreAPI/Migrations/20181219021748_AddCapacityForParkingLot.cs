using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkEco.CoreAPI.Migrations
{
    public partial class AddCapacityForParkingLot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentCount",
                table: "ParkingLots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaximumCapacity",
                table: "ParkingLots",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCount",
                table: "ParkingLots");

            migrationBuilder.DropColumn(
                name: "MaximumCapacity",
                table: "ParkingLots");
        }
    }
}
