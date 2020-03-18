using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class prov2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calle",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "provincia",
                table: "Perfiles");

            migrationBuilder.CreateTable(
                name: "EmployeeCreateViewModel",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCreateViewModel", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_provinciaID",
                table: "Perfiles",
                column: "provinciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfiles_Provincias_provinciaID",
                table: "Perfiles",
                column: "provinciaID",
                principalTable: "Provincias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfiles_Provincias_provinciaID",
                table: "Perfiles");

            migrationBuilder.DropTable(
                name: "EmployeeCreateViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Perfiles_provinciaID",
                table: "Perfiles");

            migrationBuilder.AddColumn<string>(
                name: "calle",
                table: "Perfiles",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "provincia",
                table: "Perfiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
