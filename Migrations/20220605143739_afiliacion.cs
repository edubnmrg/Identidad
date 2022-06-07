using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class afiliacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
                //name: "ZonasManuales");

            migrationBuilder.CreateTable(
                name: "Afiliaciones",
                columns: table => new
                {
                    AfiliacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Año = table.Column<int>(nullable: false),
                    Importe = table.Column<decimal>(nullable: false),
                    AutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliaciones", x => x.AfiliacionId);
                    table.ForeignKey(
                        name: "FK_Afiliaciones_Perfiles_AutId",
                        column: x => x.AutId,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Afiliaciones_Perfiles_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliaciones_AutId",
                table: "Afiliaciones",
                column: "AutId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliaciones_PerfilId",
                table: "Afiliaciones",
                column: "PerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afiliaciones");

            migrationBuilder.CreateTable(
                name: "ZonasManuales",
                columns: table => new
                {
                    ZonaManualId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ganador1 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Ganador2 = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    GanadorZona = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    Jugador1 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Jugador2 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Jugador3 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Jugador4 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Perdedor1 = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    Perdedor2 = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    Repechaje1 = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    Repechaje2 = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    SegundoZona = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    TorneoID = table.Column<int>(type: "int", nullable: false)
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
    }
}
