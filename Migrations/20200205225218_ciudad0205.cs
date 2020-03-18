using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class ciudad0205 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Provincias_prov_ID",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_prov_ID",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "prov_ID",
                table: "Ciudades");

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaID",
                table: "Ciudades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_ProvinciaID",
                table: "Ciudades",
                column: "ProvinciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Provincias_ProvinciaID",
                table: "Ciudades",
                column: "ProvinciaID",
                principalTable: "Provincias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Provincias_ProvinciaID",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_ProvinciaID",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "ProvinciaID",
                table: "Ciudades");

            migrationBuilder.AddColumn<int>(
                name: "prov_ID",
                table: "Ciudades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_prov_ID",
                table: "Ciudades",
                column: "prov_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Provincias_prov_ID",
                table: "Ciudades",
                column: "prov_ID",
                principalTable: "Provincias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
