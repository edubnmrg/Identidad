using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class zones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZonasJugadores_Zonas_ZonaID",
                table: "ZonasJugadores");

            migrationBuilder.DropIndex(
                name: "IX_ZonasJugadores_ZonaID",
                table: "ZonasJugadores");

            migrationBuilder.AddColumn<int>(
                name: "ZoneZonaID",
                table: "ZonasJugadores",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Zones",
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
                    table.PrimaryKey("PK_Zones", x => x.ZonaID);
                    table.ForeignKey(
                        name: "FK_Zones_Torneos2_TorneoID",
                        column: x => x.TorneoID,
                        principalTable: "Torneos2",
                        principalColumn: "TorneoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZonasJugadores_ZoneZonaID",
                table: "ZonasJugadores",
                column: "ZoneZonaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_TorneoID",
                table: "Zones",
                column: "TorneoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ZonasJugadores_Zones_ZoneZonaID",
                table: "ZonasJugadores",
                column: "ZoneZonaID",
                principalTable: "Zones",
                principalColumn: "ZonaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZonasJugadores_Zones_ZoneZonaID",
                table: "ZonasJugadores");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_ZonasJugadores_ZoneZonaID",
                table: "ZonasJugadores");

            migrationBuilder.DropColumn(
                name: "ZoneZonaID",
                table: "ZonasJugadores");

            migrationBuilder.CreateIndex(
                name: "IX_ZonasJugadores_ZonaID",
                table: "ZonasJugadores",
                column: "ZonaID");

            migrationBuilder.AddForeignKey(
                name: "FK_ZonasJugadores_Zonas_ZonaID",
                table: "ZonasJugadores",
                column: "ZonaID",
                principalTable: "Zonas",
                principalColumn: "ZonaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
