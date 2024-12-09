using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportProject.Migrations
{
    public partial class FixOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Offer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Offer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Offer");
        }
    }
}
