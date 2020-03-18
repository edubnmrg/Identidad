using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class ciudad2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Provincias_provinciaID",
                table: "Ciudades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciudades",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_provinciaID",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "provinciaID",
                table: "Ciudades");

            migrationBuilder.AddColumn<int>(
                name: "CiudadID",
                table: "Ciudades",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciudades",
                table: "Ciudades",
                column: "CiudadID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Provincias_prov_ID",
                table: "Ciudades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciudades",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_prov_ID",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "CiudadID",
                table: "Ciudades");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Ciudades",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "provinciaID",
                table: "Ciudades",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciudades",
                table: "Ciudades",
                column: "ID");

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
    }
}
