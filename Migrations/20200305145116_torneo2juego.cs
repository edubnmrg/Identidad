using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class torneo2juego : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rankings_Categorias_categoriaID",
                table: "Rankings");

            migrationBuilder.DropIndex(
                name: "IX_Rankings_categoriaID",
                table: "Rankings");

            migrationBuilder.DropColumn(
                name: "categoriaID",
                table: "Rankings");

            migrationBuilder.AddColumn<int>(
                name: "JuegoID",
                table: "Torneos2",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JuegoID1",
                table: "Juegoes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Juegoes_JuegoID1",
                table: "Juegoes",
                column: "JuegoID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegoes_Juegoes_JuegoID1",
                table: "Juegoes",
                column: "JuegoID1",
                principalTable: "Juegoes",
                principalColumn: "JuegoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juegoes_Juegoes_JuegoID1",
                table: "Juegoes");

            migrationBuilder.DropIndex(
                name: "IX_Juegoes_JuegoID1",
                table: "Juegoes");

            migrationBuilder.DropColumn(
                name: "JuegoID",
                table: "Torneos2");

            migrationBuilder.DropColumn(
                name: "JuegoID1",
                table: "Juegoes");

            migrationBuilder.AddColumn<int>(
                name: "categoriaID",
                table: "Rankings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_categoriaID",
                table: "Rankings",
                column: "categoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rankings_Categorias_categoriaID",
                table: "Rankings",
                column: "categoriaID",
                principalTable: "Categorias",
                principalColumn: "categoriaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
