using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class clubnofed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Federaciones_fedID",
                table: "Club");

            migrationBuilder.DropIndex(
                name: "IX_Club_fedID",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "fedID",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "fed_ID",
                table: "Club");

            migrationBuilder.AlterColumn<string>(
                name: "clubEmail",
                table: "Club",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "FedID",
                table: "Club",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Club_FederacionID",
                table: "Club",
                column: "FedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Federaciones_FederacionID",
                table: "Club",
                column: "FedID",
                principalTable: "Federaciones",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Federaciones_FederacionID",
                table: "Club");

            migrationBuilder.DropIndex(
                name: "IX_Club_FederacionID",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "FedID",
                table: "Club");

            migrationBuilder.AlterColumn<string>(
                name: "clubEmail",
                table: "Club",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "fedID",
                table: "Club",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fed_ID",
                table: "Club",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Club_fedID",
                table: "Club",
                column: "fedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Federaciones_fedID",
                table: "Club",
                column: "fedID",
                principalTable: "Federaciones",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
