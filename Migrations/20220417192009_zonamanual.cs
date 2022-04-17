using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class zonamanual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZonasManuales",
                columns: table => new
                {
                    ZonaManualId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    TorneoID = table.Column<int>(nullable: false),
                    Jugador1 = table.Column<string>(maxLength: 32, nullable: true),
                    Jugador2 = table.Column<string>(maxLength: 32, nullable: true),
                    Jugador3 = table.Column<string>(maxLength: 32, nullable: true),
                    Jugador4 = table.Column<string>(maxLength: 32, nullable: true),
                    Ganador1 = table.Column<string>(maxLength: 32, nullable: true),
                    Perdedor1 = table.Column<int>(maxLength: 32, nullable: false),
                    Ganador2 = table.Column<int>(maxLength: 32, nullable: false),
                    Perdedor2 = table.Column<int>(maxLength: 32, nullable: false),
                    GanadorZona = table.Column<int>(maxLength: 32, nullable: false),
                    Repechaje1 = table.Column<int>(maxLength: 32, nullable: false),
                    Repechaje2 = table.Column<int>(maxLength: 32, nullable: false),
                    SegundoZona = table.Column<int>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonasManuales", x => x.ZonaManualId);
                    table.ForeignKey(
                        name: "FK_ZonasManuales_Torneos2_TorneoID",
                        column: x => x.TorneoID,
                        principalTable: "Torneos2",
                        principalColumn: "TorneoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZonasManuales_TorneoID",
                table: "ZonasManuales",
                column: "TorneoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZonasManuales");
        }
    }
}
