using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class inscr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    InscripcionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilFK = table.Column<int>(nullable: false),
                    TorneoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.InscripcionID);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Club_PerfilFK",
                        column: x => x.PerfilFK,
                        principalTable: "Club",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Club_TorneoFK",
                        column: x => x.TorneoFK,
                        principalTable: "Club",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_PerfilFK",
                table: "Inscripciones",
                column: "PerfilFK");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_TorneoFK",
                table: "Inscripciones",
                column: "TorneoFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones");
        }
    }
}
