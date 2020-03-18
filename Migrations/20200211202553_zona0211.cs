using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class zona0211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zonas_Torneos2_Torneo2TorneoID",
                table: "Zonas");

           

            migrationBuilder.DropIndex(
                name: "IX_Zonas_Torneo2TorneoID",
                table: "Zonas");

            migrationBuilder.DropColumn(
                name: "Torneo2TorneoID",
                table: "Zonas");

            migrationBuilder.AddColumn<int>(
                name: "TorneoID1",
                table: "Zonas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Zonas_TorneoID1",
                table: "Zonas",
                column: "TorneoID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Zonas_Torneos2_TorneoID",
                table: "Zonas",
                column: "TorneoID",
                principalTable: "Torneos2",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zonas_Torneos2_TorneoID",
                table: "Zonas");


            migrationBuilder.DropIndex(
                name: "IX_Zonas_TorneoID1",
                table: "Zonas");

            migrationBuilder.DropColumn(
                name: "TorneoID1",
                table: "Zonas");

            migrationBuilder.AddColumn<int>(
                name: "Torneo2TorneoID",
                table: "Zonas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zonas_Torneo2TorneoID",
                table: "Zonas",
                column: "Torneo2TorneoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zonas_Torneos2_Torneo2TorneoID",
                table: "Zonas",
                column: "Torneo2TorneoID",
                principalTable: "Torneos2",
                principalColumn: "TorneoID",
                onDelete: ReferentialAction.Restrict);

           
        }
    }
}
