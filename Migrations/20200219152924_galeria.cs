using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class galeria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ganador",
                table: "Partidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Galerias",
                columns: table => new
                {
                    GaleriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoPath = table.Column<string>(maxLength: 128, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Nota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galerias", x => x.GaleriaId);
                });

            migrationBuilder.CreateTable(
                name: "GaleriasTorneos",
                columns: table => new
                {
                    GaleriaTorneosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoPath = table.Column<string>(maxLength: 128, nullable: false),
                    TorneoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Nota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriasTorneos", x => x.GaleriaTorneosId);
                    table.ForeignKey(
                        name: "FK_GaleriasTorneos_Torneos2_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Torneos2",
                        principalColumn: "TorneoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaleriasTorneos_TorneoId",
                table: "GaleriasTorneos",
                column: "TorneoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galerias");

            migrationBuilder.DropTable(
                name: "GaleriasTorneos");

            migrationBuilder.DropColumn(
                name: "Ganador",
                table: "Partidos");
        }
    }
}
