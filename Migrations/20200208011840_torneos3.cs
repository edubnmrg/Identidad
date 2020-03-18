using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class torneos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatTorFKRefId",
                table: "Torneos2");

            migrationBuilder.AddColumn<int>(
                name: "CatTorRefId",
                table: "Torneos2",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatTorRefId",
                table: "Torneos2");

            migrationBuilder.AddColumn<int>(
                name: "CatTorFKRefId",
                table: "Torneos2",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
