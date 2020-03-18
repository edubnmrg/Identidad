using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class club : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sigla",
                table: "Federaciones",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(maxLength: 128, nullable: false),
                    sigla = table.Column<string>(maxLength: 16, nullable: false),
                    calle = table.Column<string>(maxLength: 64, nullable: false),
                    altura = table.Column<int>(nullable: false),
                    ciudad = table.Column<string>(maxLength: 64, nullable: false),
                    provincia = table.Column<string>(maxLength: 64, nullable: false),
                    clubEmail = table.Column<string>(nullable: false),
                    clubUrl = table.Column<string>(maxLength: 256, nullable: false),
                    telefono = table.Column<string>(maxLength: 16, nullable: true),
                    fed_ID = table.Column<int>(nullable: false),
                    fedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Club_Federaciones_fedID",
                        column: x => x.fedID,
                        principalTable: "Federaciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Club_fedID",
                table: "Club",
                column: "fedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropColumn(
                name: "sigla",
                table: "Federaciones");
        }
    }
}
