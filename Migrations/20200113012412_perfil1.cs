using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class perfil1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(maxLength: 128, nullable: false),
                    apellido = table.Column<string>(maxLength: 128, nullable: false),
                    tDocID = table.Column<int>(nullable: false),
                    tipDocID = table.Column<int>(nullable: true),
                    calle = table.Column<string>(maxLength: 64, nullable: false),
                    altura = table.Column<int>(nullable: false),
                    ciudad = table.Column<string>(maxLength: 64, nullable: false),
                    provincia = table.Column<string>(maxLength: 64, nullable: false),
                    fedEmail = table.Column<string>(nullable: false),
                    telefono = table.Column<string>(maxLength: 16, nullable: true),
                    celular = table.Column<string>(maxLength: 16, nullable: true),
                    clubID = table.Column<int>(nullable: false),
                    foto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Perfiles_TipoDocumentos_tipDocID",
                        column: x => x.tipDocID,
                        principalTable: "TipoDocumentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_tipDocID",
                table: "Perfiles",
                column: "tipDocID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfiles");
        }
    }
}
