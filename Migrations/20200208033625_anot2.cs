using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class anot2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Torneos2_Torneo2TorneoID",
                table: "Anotaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Torneos_TorneoRefId",
                table: "Anotaciones");

            migrationBuilder.DropIndex(
                name: "IX_Anotaciones_Torneo2TorneoID",
                table: "Anotaciones");

            migrationBuilder.DropColumn(
                name: "Torneo2TorneoID",
                table: "Anotaciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Torneos2_TorneoRefId",
                table: "Anotaciones",
                column: "TorneoRefId",
                principalTable: "Torneos2",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotaciones_Torneos2_TorneoRefId",
                table: "Anotaciones");

            migrationBuilder.AddColumn<int>(
                name: "Torneo2TorneoID",
                table: "Anotaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_Torneo2TorneoID",
                table: "Anotaciones",
                column: "Torneo2TorneoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Torneos2_Torneo2TorneoID",
                table: "Anotaciones",
                column: "Torneo2TorneoID",
                principalTable: "Torneos2",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Anotaciones_Torneos_TorneoRefId",
                table: "Anotaciones",
                column: "TorneoRefId",
                principalTable: "Torneos",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
