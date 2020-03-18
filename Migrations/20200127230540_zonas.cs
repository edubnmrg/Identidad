using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class zonas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    ZonaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TorneoID = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    CantidadJugadores = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.ZonaID);
                    
                });

            migrationBuilder.CreateTable(
                name: "ZonasJugadores",
                columns: table => new
                {
                    ZonaJugadorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonaID = table.Column<int>(nullable: false),
                    JugadorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonasJugadores", x => x.ZonaJugadorID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zonas_TorneoID",
                table: "Zonas",
                column: "TorneoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zonas");

            migrationBuilder.DropTable(
                name: "ZonasJugadores");
        }
    }
}
