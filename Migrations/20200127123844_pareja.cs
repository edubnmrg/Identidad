using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class pareja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TorneoID",
                table: "Inscripciones",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_TorneoID",
                table: "Inscripciones",
                column: "TorneoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Torneos_TorneoID",
                table: "Inscripciones",
                column: "TorneoID",
                principalTable: "Torneos",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Torneos_TorneoID",
                table: "Inscripciones");

            migrationBuilder.DropIndex(
                name: "IX_Inscripciones_TorneoID",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "TorneoID",
                table: "Inscripciones");
        }
    }
}
