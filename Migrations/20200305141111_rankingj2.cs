using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class rankingj2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoriaID",
                table: "Rankings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rankings2",
                columns: table => new
                {
                    RankingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilID = table.Column<int>(nullable: false),
                    CategoriaID = table.Column<int>(nullable: false),
                    JuegoID = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Puntos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rankings2", x => x.RankingID);
                    table.ForeignKey(
                        name: "FK_Rankings2_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "categoriaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rankings2_Juegoes_JuegoID",
                        column: x => x.JuegoID,
                        principalTable: "Juegoes",
                        principalColumn: "JuegoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rankings2_Perfiles_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_categoriaID",
                table: "Rankings",
                column: "categoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rankings2_CategoriaID",
                table: "Rankings2",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rankings2_JuegoID",
                table: "Rankings2",
                column: "JuegoID");

            migrationBuilder.CreateIndex(
                name: "IX_Rankings2_PerfilID",
                table: "Rankings2",
                column: "PerfilID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rankings_Categorias_categoriaID",
                table: "Rankings",
                column: "categoriaID",
                principalTable: "Categorias",
                principalColumn: "categoriaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rankings_Categorias_categoriaID",
                table: "Rankings");

            migrationBuilder.DropTable(
                name: "Rankings2");

            migrationBuilder.DropIndex(
                name: "IX_Rankings_categoriaID",
                table: "Rankings");

            migrationBuilder.DropColumn(
                name: "categoriaID",
                table: "Rankings");
        }
    }
}
