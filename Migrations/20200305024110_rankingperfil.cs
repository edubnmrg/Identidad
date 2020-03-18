using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class rankingperfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rankings_PerfilID",
                table: "Rankings",
                column: "PerfilID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rankings_Perfiles_PerfilID",
                table: "Rankings",
                column: "PerfilID",
                principalTable: "Perfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rankings_Perfiles_PerfilID",
                table: "Rankings");

            migrationBuilder.DropIndex(
                name: "IX_Rankings_PerfilID",
                table: "Rankings");
        }
    }
}
