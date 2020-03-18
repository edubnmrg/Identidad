using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class provincia1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "provinciaID",
                table: "Ciudades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_provinciaID",
                table: "Ciudades",
                column: "provinciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Provincias_provinciaID",
                table: "Ciudades",
                column: "provinciaID",
                principalTable: "Provincias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Provincias_provinciaID",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_provinciaID",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "provinciaID",
                table: "Ciudades");
        }
    }
}
