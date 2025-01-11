using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportProject.Migrations
{
    public partial class fixedRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Router",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Router",
                table: "Job");
        }
    }
}
