using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class fed0204 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Federaciones_FederacionID",
                table: "Club");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Federaciones",
                table: "Federaciones");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Federaciones");

            migrationBuilder.DropColumn(
                name: "provincia",
                table: "Federaciones");

            migrationBuilder.RenameColumn(
                name: "fedUrl",
                table: "Federaciones",
                newName: "FedUrl");

            migrationBuilder.AlterColumn<string>(
                name: "FedUrl",
                table: "Federaciones",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "FedID",
                table: "Federaciones",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Federaciones",
                table: "Federaciones",
                column: "FedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Federaciones_FederacionID",
                table: "Club",
                column: "FedID",
                principalTable: "Federaciones",
                principalColumn: "FedID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Federaciones_FederacionID",
                table: "Club");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Federaciones",
                table: "Federaciones");

            migrationBuilder.DropColumn(
                name: "FedID",
                table: "Federaciones");

            migrationBuilder.RenameColumn(
                name: "FedUrl",
                table: "Federaciones",
                newName: "fedUrl");

            migrationBuilder.AlterColumn<string>(
                name: "fedUrl",
                table: "Federaciones",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Federaciones",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "provincia",
                table: "Federaciones",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Federaciones",
                table: "Federaciones",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Federaciones_FederacionID",
                table: "Club",
                column: "FedID",
                principalTable: "Federaciones",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
