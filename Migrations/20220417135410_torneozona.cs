using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class torneozona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Puntos",
                table: "Torneos2",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "Torneos2",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SisZonId",
                table: "Torneos2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SisZonRefId",
                table: "Torneos2",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SistemaZona",
                columns: table => new
                {
                    SisZonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sistema = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaZona", x => x.SisZonId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Torneos2_SisZonId",
                table: "Torneos2",
                column: "SisZonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Torneos2_SistemaZona_SisZonId",
                table: "Torneos2",
                column: "SisZonId",
                principalTable: "SistemaZona",
                principalColumn: "SisZonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Torneos2_SistemaZona_SisZonId",
                table: "Torneos2");

            migrationBuilder.DropTable(
                name: "SistemaZona");

            migrationBuilder.DropIndex(
                name: "IX_Torneos2_SisZonId",
                table: "Torneos2");

            migrationBuilder.DropColumn(
                name: "Puntos",
                table: "Torneos2");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Torneos2");

            migrationBuilder.DropColumn(
                name: "SisZonId",
                table: "Torneos2");

            migrationBuilder.DropColumn(
                name: "SisZonRefId",
                table: "Torneos2");
        }
    }
}
