using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class perfil200114 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfiles_TipoDocumentos_tipDocID",
                table: "Perfiles");

            migrationBuilder.DropIndex(
                name: "IX_Perfiles_tipDocID",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "fedEmail",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "tipDocID",
                table: "Perfiles");

            migrationBuilder.AlterColumn<string>(
                name: "provincia",
                table: "Perfiles",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Perfiles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "numeroDocumento",
                table: "Perfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "provinciaID",
                table: "Perfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipoDeDocumentoID",
                table: "Perfiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_clubID",
                table: "Perfiles",
                column: "clubID");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_tipoDeDocumentoID",
                table: "Perfiles",
                column: "tipoDeDocumentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfiles_Club_clubID",
                table: "Perfiles",
                column: "clubID",
                principalTable: "Club",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfiles_TipoDocumentos_tipoDeDocumentoID",
                table: "Perfiles",
                column: "tipoDeDocumentoID",
                principalTable: "TipoDocumentos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfiles_Club_clubID",
                table: "Perfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Perfiles_TipoDocumentos_tipoDeDocumentoID",
                table: "Perfiles");

            migrationBuilder.DropIndex(
                name: "IX_Perfiles_clubID",
                table: "Perfiles");

            migrationBuilder.DropIndex(
                name: "IX_Perfiles_tipoDeDocumentoID",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "numeroDocumento",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "provinciaID",
                table: "Perfiles");

            migrationBuilder.DropColumn(
                name: "tipoDeDocumentoID",
                table: "Perfiles");

            migrationBuilder.AlterColumn<string>(
                name: "provincia",
                table: "Perfiles",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fedEmail",
                table: "Perfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "tipDocID",
                table: "Perfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_tipDocID",
                table: "Perfiles",
                column: "tipDocID");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfiles_TipoDocumentos_tipDocID",
                table: "Perfiles",
                column: "tipDocID",
                principalTable: "TipoDocumentos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
