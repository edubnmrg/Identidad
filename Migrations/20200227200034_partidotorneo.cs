using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class partidotorneo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TorneoID",
                table: "Partidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_TorneoID",
                table: "Partidos",
                column: "TorneoID");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropIndex(
                name: "IX_Partidos_TorneoID",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "TorneoID",
                table: "Partidos");
        }
    }
}
