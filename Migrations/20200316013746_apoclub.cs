using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class apoclub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApoderadosClub",
                columns: table => new
                {
                    ApoClubID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubID = table.Column<int>(nullable: false),
                    PerfilID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApoderadosClub", x => x.ApoClubID);
                    table.ForeignKey(
                        name: "FK_ApoderadosClub_Club_ClubID",
                        column: x => x.ClubID,
                        principalTable: "Club",
                        principalColumn: "ClubID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApoderadosClub_Perfiles_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApoderadosClub_ClubID",
                table: "ApoderadosClub",
                column: "ClubID");

            migrationBuilder.CreateIndex(
                name: "IX_ApoderadosClub_PerfilID",
                table: "ApoderadosClub",
                column: "PerfilID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApoderadosClub");
        }
    }
}
