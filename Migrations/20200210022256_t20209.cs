using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class t20209 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Torneos2_Torneo2TorneoID",
                table: "Inscripciones");

            migrationBuilder.DropIndex(
                name: "IX_Inscripciones_Torneo2TorneoID",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "Torneo2TorneoID",
                table: "Inscripciones");

            migrationBuilder.AddColumn<int>(
                name: "Torneo2TorneoID",
                table: "Zonas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zonas_Torneo2TorneoID",
                table: "Zonas",
                column: "Torneo2TorneoID");

            migrationBuilder.CreateIndex(
                name: "IXPareja",
                table: "Parejas",
                columns: new[] { "Jugador1", "Jugador2" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zonas_Torneos2_Torneo2TorneoID",
                table: "Zonas",
                column: "Torneo2TorneoID",
                principalTable: "Torneos2",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zonas_Torneos2_Torneo2TorneoID",
                table: "Zonas");

            migrationBuilder.DropIndex(
                name: "IX_Zonas_Torneo2TorneoID",
                table: "Zonas");

            migrationBuilder.DropIndex(
                name: "IXPareja",
                table: "Parejas");

            migrationBuilder.DropColumn(
                name: "Torneo2TorneoID",
                table: "Zonas");

            migrationBuilder.AddColumn<int>(
                name: "Torneo2TorneoID",
                table: "Inscripciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_Torneo2TorneoID",
                table: "Inscripciones",
                column: "Torneo2TorneoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Torneos2_Torneo2TorneoID",
                table: "Inscripciones",
                column: "Torneo2TorneoID",
                principalTable: "Torneos2",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
