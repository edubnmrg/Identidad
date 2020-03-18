using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class clasificados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClasificadoID",
                table: "Torneos2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClasificadoID",
                table: "Perfiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clasificados",
                columns: table => new
                {
                    ClasificadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TorneoID = table.Column<int>(nullable: false),
                    PerfilID = table.Column<int>(nullable: false),
                    Promedio = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificados", x => x.ClasificadoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Torneos2_ClasificadoID",
                table: "Torneos2",
                column: "ClasificadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_ClasificadoID",
                table: "Perfiles",
                column: "ClasificadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfiles_Clasificados_ClasificadoID",
                table: "Perfiles",
                column: "ClasificadoID",
                principalTable: "Clasificados",
                principalColumn: "ClasificadoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Torneos2_Clasificados_ClasificadoID",
                table: "Torneos2",
                column: "ClasificadoID",
                principalTable: "Clasificados",
                principalColumn: "ClasificadoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfiles_Clasificados_ClasificadoID",
                table: "Perfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Torneos2_Clasificados_ClasificadoID",
                table: "Torneos2");

            migrationBuilder.DropTable(
                name: "Clasificados");

            migrationBuilder.DropIndex(
                name: "IX_Torneos2_ClasificadoID",
                table: "Torneos2");

            migrationBuilder.DropIndex(
                name: "IX_Perfiles_ClasificadoID",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "ClasificadoID",
                table: "Torneos2");

            migrationBuilder.DropColumn(
                name: "ClasificadoID",
                table: "Perfiles");
        }
    }
}
