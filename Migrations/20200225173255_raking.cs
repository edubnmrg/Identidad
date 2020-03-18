using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class raking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rankings",
                columns: table => new
                {
                    RankingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilID = table.Column<int>(nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Puntos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rankings", x => x.RankingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rankings");
        }
    }
}
