using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class anot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Club_PerfilFK",
                table: "Anotaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Club_TorneoFK",
                table: "Anotaciones");

            migrationBuilder.DropIndex(
                name: "IX_Anotaciones_PerfilFK",
                table: "Anotaciones");

            migrationBuilder.DropIndex(
                name: "IX_Anotaciones_TorneoFK",
                table: "Anotaciones");

            migrationBuilder.DropColumn(
                name: "PerfilFK",
                table: "Anotaciones");

            migrationBuilder.DropColumn(
                name: "TorneoFK",
                table: "Anotaciones");

            migrationBuilder.AddColumn<int>(
                name: "PerfilID",
                table: "Anotaciones",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerfilRefId",
                table: "Anotaciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Torneo2TorneoID",
                table: "Anotaciones",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TorneoRefId",
                table: "Anotaciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_PerfilID",
                table: "Anotaciones",
                column: "PerfilID");

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_PerfilRefId",
                table: "Anotaciones",
                column: "PerfilRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_Torneo2TorneoID",
                table: "Anotaciones",
                column: "Torneo2TorneoID");

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_TorneoRefId",
                table: "Anotaciones",
                column: "TorneoRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Perfiles_PerfilID",
                table: "Anotaciones",
                column: "PerfilID",
                principalTable: "Perfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Club_PerfilRefId",
                table: "Anotaciones",
                column: "PerfilRefId",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Torneos2_Torneo2TorneoID",
                table: "Anotaciones",
                column: "Torneo2TorneoID",
                principalTable: "Torneos2",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Club_TorneoRefId",
                table: "Anotaciones",
                column: "TorneoRefId",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Perfiles_PerfilID",
                table: "Anotaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Club_PerfilRefId",
                table: "Anotaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Torneos2_Torneo2TorneoID",
                table: "Anotaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Club_TorneoRefId",
                table: "Anotaciones");

            migrationBuilder.DropIndex(
                name: "IX_Anotaciones_PerfilID",
                table: "Anotaciones");

            migrationBuilder.DropIndex(
                name: "IX_Anotaciones_PerfilRefId",
                table: "Anotaciones");

            migrationBuilder.DropIndex(
                name: "IX_Anotaciones_Torneo2TorneoID",
                table: "Anotaciones");

            migrationBuilder.DropIndex(
                name: "IX_Anotaciones_TorneoRefId",
                table: "Anotaciones");

            migrationBuilder.DropColumn(
                name: "PerfilID",
                table: "Anotaciones");

            migrationBuilder.DropColumn(
                name: "PerfilRefId",
                table: "Anotaciones");

            migrationBuilder.DropColumn(
                name: "Torneo2TorneoID",
                table: "Anotaciones");

            migrationBuilder.DropColumn(
                name: "TorneoRefId",
                table: "Anotaciones");

            migrationBuilder.AddColumn<int>(
                name: "PerfilFK",
                table: "Anotaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TorneoFK",
                table: "Anotaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_PerfilFK",
                table: "Anotaciones",
                column: "PerfilFK");

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_TorneoFK",
                table: "Anotaciones",
                column: "TorneoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Club_PerfilFK",
                table: "Anotaciones",
                column: "PerfilFK",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Club_TorneoFK",
                table: "Anotaciones",
                column: "TorneoFK",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
