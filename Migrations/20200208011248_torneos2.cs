using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class torneos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Torneo2TorneoID",
                table: "Inscripciones",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Torneos2",
                columns: table => new
                {
                    TorneoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTorneo = table.Column<string>(maxLength: 128, nullable: false),
                    ClubRefId = table.Column<int>(nullable: false),
                    CatTorFKRefId = table.Column<int>(nullable: false),
                    catTorneoID = table.Column<int>(nullable: true),
                    CanJugRefId = table.Column<int>(nullable: false),
                    CanJugcantJugID = table.Column<int>(nullable: true),
                    CatRefId = table.Column<int>(nullable: false),
                    categoriaID = table.Column<int>(nullable: true),
                    SisTorRefId = table.Column<int>(nullable: false),
                    sisTorID = table.Column<int>(nullable: true),
                    Desde = table.Column<DateTime>(nullable: false),
                    Hasta = table.Column<DateTime>(nullable: false),
                    ValorInscripcion = table.Column<decimal>(type: "decimal(16 ,0)", nullable: false),
                    Notas = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneos2", x => x.TorneoID);
                    table.ForeignKey(
                        name: "FK_Torneos2_CantidadJugadores_CanJugcantJugID",
                        column: x => x.CanJugcantJugID,
                        principalTable: "CantidadJugadores",
                        principalColumn: "cantJugID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Torneos2_Club_ClubRefId",
                        column: x => x.ClubRefId,
                        principalTable: "Club",
                        principalColumn: "ClubID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Torneos2_CategoriasTorneos_catTorneoID",
                        column: x => x.catTorneoID,
                        principalTable: "CategoriasTorneos",
                        principalColumn: "catTorneoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Torneos2_Categorias_categoriaID",
                        column: x => x.categoriaID,
                        principalTable: "Categorias",
                        principalColumn: "categoriaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Torneos2_SistemasTorneos_sisTorID",
                        column: x => x.sisTorID,
                        principalTable: "SistemasTorneos",
                        principalColumn: "sisTorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_Torneo2TorneoID",
                table: "Inscripciones",
                column: "Torneo2TorneoID");

            migrationBuilder.CreateIndex(
                name: "IX_Torneos2_CanJugcantJugID",
                table: "Torneos2",
                column: "CanJugcantJugID");

            migrationBuilder.CreateIndex(
                name: "IX_Torneos2_ClubRefId",
                table: "Torneos2",
                column: "ClubRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Torneos2_catTorneoID",
                table: "Torneos2",
                column: "catTorneoID");

            migrationBuilder.CreateIndex(
                name: "IX_Torneos2_categoriaID",
                table: "Torneos2",
                column: "categoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Torneos2_sisTorID",
                table: "Torneos2",
                column: "sisTorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Torneos2_Torneo2TorneoID",
                table: "Inscripciones",
                column: "Torneo2TorneoID",
                principalTable: "Torneos2",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Torneos2_Torneo2TorneoID",
                table: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Torneos2");

            migrationBuilder.DropIndex(
                name: "IX_Inscripciones_Torneo2TorneoID",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "Torneo2TorneoID",
                table: "Inscripciones");
        }
    }
}
