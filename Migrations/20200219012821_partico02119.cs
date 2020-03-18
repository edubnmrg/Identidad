using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class partico02119 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    PartidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jugador1Id = table.Column<int>(nullable: false),
                    Perfil1ID = table.Column<int>(nullable: true),
                    Jugador2Id = table.Column<int>(nullable: false),
                    PerfilID = table.Column<int>(nullable: true),
                    ZonaId = table.Column<int>(nullable: false),
                    EtapaId = table.Column<int>(nullable: false),
                    PartidoNumero = table.Column<int>(nullable: false),
                    Cerrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.PartidoId);
                    table.ForeignKey(
                        name: "FK_Partidos_Etapas_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapas",
                        principalColumn: "EtapaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Perfiles_Perfil1ID",
                        column: x => x.Perfil1ID,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Perfiles_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zonas",
                        principalColumn: "ZonaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    ScoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidoId = table.Column<int>(nullable: false),
                    Score1 = table.Column<int>(nullable: false),
                    Score2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.ScoreId);
                    table.ForeignKey(
                        name: "FK_Score_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "PartidoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EtapaId",
                table: "Partidos",
                column: "EtapaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Perfil1ID",
                table: "Partidos",
                column: "Perfil1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_PerfilID",
                table: "Partidos",
                column: "PerfilID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_ZonaId",
                table: "Partidos",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_PartidoId",
                table: "Score",
                column: "PartidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Partidos");
        }
    }
}
