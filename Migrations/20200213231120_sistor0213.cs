using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class sistor0213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Anotaciones_TorneoRefId",
                table: "Anotaciones");

            migrationBuilder.AddColumn<int>(
                name: "CantSets",
                table: "SistemasTorneos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Puntos",
                table: "SistemasTorneos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IXPerTor",
                table: "Anotaciones",
                columns: new[] { "TorneoRefId", "PerfilRefId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IXPerTor",
                table: "Anotaciones");

            migrationBuilder.DropColumn(
                name: "CantSets",
                table: "SistemasTorneos");

            migrationBuilder.DropColumn(
                name: "Puntos",
                table: "SistemasTorneos");

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_TorneoRefId",
                table: "Anotaciones",
                column: "TorneoRefId");
        }
    }
}
