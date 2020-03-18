using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class clubpresidente2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PresidentesClub_ClubID",
                table: "PresidentesClub");

            migrationBuilder.AddColumn<int>(
                name: "PresClubID",
                table: "Club",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PresidentesClub_ClubID",
                table: "PresidentesClub",
                column: "ClubID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PresidentesClub_ClubID",
                table: "PresidentesClub");

            migrationBuilder.DropColumn(
                name: "PresClubID",
                table: "Club");

            migrationBuilder.CreateIndex(
                name: "IX_PresidentesClub_ClubID",
                table: "PresidentesClub",
                column: "ClubID");
        }
    }
}
