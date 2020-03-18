using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class presfed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PresidentesFederacion",
                columns: table => new
                {
                    PresFedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FedID = table.Column<int>(nullable: false),
                    PerfilID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresidentesFederacion", x => x.PresFedID);
                    table.ForeignKey(
                        name: "FK_PresidentesFederacion_Federaciones_FederacionID",
                        column: x => x.FedID,
                        principalTable: "Federaciones",
                        principalColumn: "FedID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresidentesFederacion_Perfiles_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresidentesFederacion_FederacionID",
                table: "PresidentesFederacion",
                column: "FedID");

            migrationBuilder.CreateIndex(
                name: "IX_PresidentesFederacion_PerfilID",
                table: "PresidentesFederacion",
                column: "PerfilID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresidentesFederacion");
        }
    }
}
