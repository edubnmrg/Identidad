using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class eliminados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eliminados",
                columns: table => new
                {
                    ElininadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TorneoID = table.Column<int>(nullable: false),
                    PerfilID = table.Column<int>(nullable: false),
                    Puesto = table.Column<int>(nullable: false),
                    Promedio = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eliminados", x => x.ElininadoID);
                    table.ForeignKey(
                        name: "FK_Eliminados_Perfiles_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eliminados_Torneos2_TorneoID",
                        column: x => x.TorneoID,
                        principalTable: "Torneos2",
                        principalColumn: "TorneoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eliminados_PerfilID",
                table: "Eliminados",
                column: "PerfilID");

            migrationBuilder.CreateIndex(
                name: "IX_Eliminados_TorneoID",
                table: "Eliminados",
                column: "TorneoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eliminados");
        }
    }
}
