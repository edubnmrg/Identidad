using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class ordenamientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenamientos",
                columns: table => new
                {
                    OrdenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jugadores = table.Column<int>(nullable: false),
                    Partidoumero = table.Column<int>(nullable: false),
                    Jugador1 = table.Column<int>(nullable: false),
                    Jugador2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenamientos", x => x.OrdenID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordenamientos");
        }
    }
}
