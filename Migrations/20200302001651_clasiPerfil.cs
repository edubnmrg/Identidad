using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class clasiPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfiles_Clasificados_ClasificadoID",
                table: "Perfiles");

            migrationBuilder.DropIndex(
                name: "IX_Perfiles_ClasificadoID",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "ClasificadoID",
                table: "Perfiles");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificados_PerfilID",
                table: "Clasificados",
                column: "PerfilID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clasificados_Perfiles_PerfilID",
                table: "Clasificados",
                column: "PerfilID",
                principalTable: "Perfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clasificados_Perfiles_PerfilID",
                table: "Clasificados");

            migrationBuilder.DropIndex(
                name: "IX_Clasificados_PerfilID",
                table: "Clasificados");

            migrationBuilder.AddColumn<int>(
                name: "ClasificadoID",
                table: "Perfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_ClasificadoID",
                table: "Perfiles",
                column: "ClasificadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfiles_Clasificados_ClasificadoID",
                table: "Perfiles",
                column: "ClasificadoID",
                principalTable: "Clasificados",
                principalColumn: "ClasificadoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
