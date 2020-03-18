using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class zonajugador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           


           

            migrationBuilder.DropColumn(
                name: "JugadorID",
                table: "ZonasJugadores");

          

            migrationBuilder.AddColumn<int>(
                name: "PerfilID",
                table: "ZonasJugadores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ZonasJugadores_PerfilID",
                table: "ZonasJugadores",
                column: "PerfilID");

            migrationBuilder.CreateIndex(
                name: "IX_ZonasJugadores_ZonaID",
                table: "ZonasJugadores",
                column: "ZonaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Perfiles_PerfilFK",
                table: "Inscripciones",
                column: "PerfilFK",
                principalTable: "Perfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Torneos_TorneoFK",
                table: "Inscripciones",
                column: "TorneoFK",
                principalTable: "Torneos",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZonasJugadores_Perfiles_PerfilID",
                table: "ZonasJugadores",
                column: "PerfilID",
                principalTable: "Perfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZonasJugadores_Zonas_ZonaID",
                table: "ZonasJugadores",
                column: "ZonaID",
                principalTable: "Zonas",
                principalColumn: "ZonaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Perfiles_PerfilFK",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Torneos_TorneoFK",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ZonasJugadores_Perfiles_PerfilID",
                table: "ZonasJugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_ZonasJugadores_Zonas_ZonaID",
                table: "ZonasJugadores");

            migrationBuilder.DropIndex(
                name: "IX_ZonasJugadores_PerfilID",
                table: "ZonasJugadores");

            migrationBuilder.DropIndex(
                name: "IX_ZonasJugadores_ZonaID",
                table: "ZonasJugadores");

            migrationBuilder.DropColumn(
                name: "PerfilID",
                table: "ZonasJugadores");

            migrationBuilder.AddColumn<int>(
                name: "JugadorID",
                table: "ZonasJugadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TorneoID",
                table: "Inscripciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_TorneoID",
                table: "Inscripciones",
                column: "TorneoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Club_PerfilFK",
                table: "Inscripciones",
                column: "PerfilFK",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Club_TorneoFK",
                table: "Inscripciones",
                column: "TorneoFK",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Torneos_TorneoID",
                table: "Inscripciones",
                column: "TorneoID",
                principalTable: "Torneos",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
