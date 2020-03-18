using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class partico021191 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Zonas_ZonaId",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_ZonaId",
                table: "Partidos");

            migrationBuilder.AddColumn<int>(
                name: "ZoneZonaID",
                table: "Partidos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_ZoneZonaID",
                table: "Partidos",
                column: "ZoneZonaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Zones_ZoneZonaID",
                table: "Partidos",
                column: "ZoneZonaID",
                principalTable: "Zones",
                principalColumn: "ZonaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Zones_ZoneZonaID",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_ZoneZonaID",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "ZoneZonaID",
                table: "Partidos");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_ZonaId",
                table: "Partidos",
                column: "ZonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Zonas_ZonaId",
                table: "Partidos",
                column: "ZonaId",
                principalTable: "Zonas",
                principalColumn: "ZonaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
