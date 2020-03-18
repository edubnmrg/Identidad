using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class torneo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Torneos",
                columns: table => new
                {
                    TorneoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTorneo = table.Column<string>(maxLength: 128, nullable: false),
                    ClubFK = table.Column<int>(nullable: false),
                    CatTorFK = table.Column<int>(nullable: false),
                    CanJugFK = table.Column<int>(nullable: false),
                    CatFK = table.Column<int>(nullable: false),
                    SisTorFK = table.Column<int>(nullable: false),
                    Desde = table.Column<DateTime>(nullable: false),
                    Hasta = table.Column<DateTime>(nullable: false),
                    ValorInscripcion = table.Column<decimal>(type: "decimal(16 ,0)", nullable: false),
                    Notas = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneos", x => x.TorneoID);
                    
                    table.ForeignKey(
                        name: "FK_Torneos_Club_ClubFK",
                        column: x => x.ClubFK,
                        principalTable: "Club",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_Torneos_ClubFK",
                table: "Torneos",
                column: "ClubFK");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Torneos");
        }
    }
}
