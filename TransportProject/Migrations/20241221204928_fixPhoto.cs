using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportProject.Migrations
{
    public partial class fixPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VehiclePhoto",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserProfilePhoto",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehiclePhoto",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UserProfilePhoto",
                table: "Users");
        }
    }
}
