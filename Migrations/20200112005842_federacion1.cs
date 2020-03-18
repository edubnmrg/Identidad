using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class federacion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Federaciones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(maxLength: 128, nullable: false),
                    calle = table.Column<string>(maxLength: 64, nullable: false),
                    altura = table.Column<int>(nullable: false),
                    ciudad = table.Column<string>(maxLength: 64, nullable: false),
                    provincia = table.Column<string>(maxLength: 64, nullable: false),
                    fedEmail = table.Column<string>(nullable: false),
                    fedUrl = table.Column<string>(maxLength: 256, nullable: false),
                    telefono = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Federaciones", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Federaciones");
        }
    }
}
