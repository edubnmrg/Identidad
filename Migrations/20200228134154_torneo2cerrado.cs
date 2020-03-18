using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class torneo2cerrado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CrucesCerrados",
                table: "Torneos2",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TorneoCerrado",
                table: "Torneos2",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ZonasCerradas",
                table: "Torneos2",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrucesCerrados",
                table: "Torneos2");

            migrationBuilder.DropColumn(
                name: "TorneoCerrado",
                table: "Torneos2");

            migrationBuilder.DropColumn(
                name: "ZonasCerradas",
                table: "Torneos2");
        }
    }
}
