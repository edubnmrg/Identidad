using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class clasitorneo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Torneos2_Clasificados_ClasificadoID",
                table: "Torneos2");

            migrationBuilder.DropIndex(
                name: "IX_Torneos2_ClasificadoID",
                table: "Torneos2");

            migrationBuilder.DropColumn(
                name: "ClasificadoID",
                table: "Torneos2");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificados_TorneoID",
                table: "Clasificados",
                column: "TorneoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clasificados_Torneos2_TorneoID",
                table: "Clasificados",
                column: "TorneoID",
                principalTable: "Torneos2",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clasificados_Torneos2_TorneoID",
                table: "Clasificados");

            migrationBuilder.DropIndex(
                name: "IX_Clasificados_TorneoID",
                table: "Clasificados");

            migrationBuilder.AddColumn<int>(
                name: "ClasificadoID",
                table: "Torneos2",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Torneos2_ClasificadoID",
                table: "Torneos2",
                column: "ClasificadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Torneos2_Clasificados_ClasificadoID",
                table: "Torneos2",
                column: "ClasificadoID",
                principalTable: "Clasificados",
                principalColumn: "ClasificadoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
