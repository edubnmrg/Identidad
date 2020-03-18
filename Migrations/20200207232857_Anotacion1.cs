using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class Anotacion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anotaciones",
                columns: table => new
                {
                    AnotacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilFK = table.Column<int>(nullable: false),
                    TorneoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anotaciones", x => x.AnotacionID);
                    table.ForeignKey(
                        name: "FK_Anotaciones_Club_PerfilFK",
                        column: x => x.PerfilFK,
                        principalTable: "Club",
                        principalColumn: "ClubID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anotaciones_Club_TorneoFK",
                        column: x => x.TorneoFK,
                        principalTable: "Club",
                        principalColumn: "ClubID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_PerfilFK",
                table: "Anotaciones",
                column: "PerfilFK");

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_TorneoFK",
                table: "Anotaciones",
                column: "TorneoFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anotaciones");
        }
    }
}
