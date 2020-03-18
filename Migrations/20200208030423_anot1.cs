using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class anot1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Perfiles_PerfilID",
                table: "Anotaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Club_PerfilRefId",
                table: "Anotaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Club_TorneoRefId",
                table: "Anotaciones");

            migrationBuilder.DropIndex(
                name: "IX_Anotaciones_PerfilID",
                table: "Anotaciones");

            migrationBuilder.DropColumn(
                name: "PerfilID",
                table: "Anotaciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Perfiles_PerfilRefId",
                table: "Anotaciones",
                column: "PerfilRefId",
                principalTable: "Perfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Torneos_TorneoRefId",
                table: "Anotaciones",
                column: "TorneoRefId",
                principalTable: "Torneos",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Perfiles_PerfilRefId",
                table: "Anotaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Torneos_TorneoRefId",
                table: "Anotaciones");

            migrationBuilder.AddColumn<int>(
                name: "PerfilID",
                table: "Anotaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_PerfilID",
                table: "Anotaciones",
                column: "PerfilID");

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
                name: "FK_Anotaciones_Club_TorneoRefId",
                table: "Anotaciones",
                column: "TorneoRefId",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
