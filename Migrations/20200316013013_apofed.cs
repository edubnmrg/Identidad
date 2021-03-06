﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class apofed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApoderadosFederacion",
                columns: table => new
                {
                    ApoFedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FedID = table.Column<int>(nullable: false),
                    PerfilID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApoderadosFederacion", x => x.ApoFedID);
                    table.ForeignKey(
                        name: "FK_ApoderadosFederacion_Federaciones_FederacionID",
                        column: x => x.FedID,
                        principalTable: "Federaciones",
                        principalColumn: "FedID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApoderadosFederacion_Perfiles_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApoderadosFederacion_FederacionID",
                table: "ApoderadosFederacion",
                column: "FedID");

            migrationBuilder.CreateIndex(
                name: "IX_ApoderadosFederacion_PerfilID",
                table: "ApoderadosFederacion",
                column: "PerfilID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApoderadosFederacion");
        }
    }
}
