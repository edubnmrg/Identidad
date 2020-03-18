using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class clubnofed0204 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "provincia",
                table: "Club");

            migrationBuilder.AddColumn<int>(
                name: "provinciaID",
                table: "Federaciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FedID",
                table: "Club",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "provinciaID",
                table: "Club",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Federaciones_provinciaID",
                table: "Federaciones",
                column: "provinciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Club_provinciaID",
                table: "Club",
                column: "provinciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Provincias_provinciaID",
                table: "Club",
                column: "provinciaID",
                principalTable: "Provincias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Federaciones_Provincias_provinciaID",
                table: "Federaciones",
                column: "provinciaID",
                principalTable: "Provincias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Provincias_provinciaID",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Federaciones_Provincias_provinciaID",
                table: "Federaciones");

            migrationBuilder.DropIndex(
                name: "IX_Federaciones_provinciaID",
                table: "Federaciones");

            migrationBuilder.DropIndex(
                name: "IX_Club_provinciaID",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "provinciaID",
                table: "Federaciones");

            migrationBuilder.DropColumn(
                name: "provinciaID",
                table: "Club");

            migrationBuilder.AlterColumn<int>(
                name: "FedID",
                table: "Club",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "provincia",
                table: "Club",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }
    }
}
