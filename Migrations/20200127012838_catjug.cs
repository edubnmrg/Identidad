using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class catjug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasJugadores",
                columns: table => new
                {
                    InscripcionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilFK = table.Column<int>(nullable: false),
                    JuegoFK = table.Column<int>(nullable: false),
                    CategoriaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasJugadores", x => x.InscripcionID);
                    table.ForeignKey(
                        name: "FK_CategoriasJugadores_Club_CategoriaFK",
                        column: x => x.CategoriaFK,
                        principalTable: "Club",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoriasJugadores_Club_JuegoFK",
                        column: x => x.JuegoFK,
                        principalTable: "Club",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoriasJugadores_Club_PerfilFK",
                        column: x => x.PerfilFK,
                        principalTable: "Club",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasJugadores_CategoriaFK",
                table: "CategoriasJugadores",
                column: "CategoriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasJugadores_JuegoFK",
                table: "CategoriasJugadores",
                column: "JuegoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasJugadores_PerfilFK",
                table: "CategoriasJugadores",
                column: "PerfilFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriasJugadores");
        }
    }
}
