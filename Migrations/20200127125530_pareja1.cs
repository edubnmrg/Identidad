using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class pareja1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parejas",
                columns: table => new
                {
                    ParejaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jugador1 = table.Column<int>(nullable: false),
                    Perfil1ID = table.Column<int>(nullable: true),
                    Jugador2 = table.Column<int>(nullable: false),
                    Perfil2ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parejas", x => x.ParejaID);
                    table.ForeignKey(
                        name: "FK_Parejas_Perfiles_Perfil1ID",
                        column: x => x.Perfil1ID,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parejas_Perfiles_Perfil2ID",
                        column: x => x.Perfil2ID,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parejas_Perfil1ID",
                table: "Parejas",
                column: "Perfil1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Parejas_Perfil2ID",
                table: "Parejas",
                column: "Perfil2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parejas");
        }
    }
}
