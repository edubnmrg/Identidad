using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class club0205 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Provincias_provinciaID",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Club_PerfilFK",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Club_TorneoFK",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Perfiles_Club_clubID",
                table: "Perfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Torneos_Club_ClubFK",
                table: "Torneos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Club",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "nombre",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "sigla",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "telefono",
                table: "Club",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "provinciaID",
                table: "Club",
                newName: "ProvinciaID");

            migrationBuilder.RenameColumn(
                name: "clubUrl",
                table: "Club",
                newName: "ClubUrl");

            migrationBuilder.RenameColumn(
                name: "clubEmail",
                table: "Club",
                newName: "ClubEmail");

            migrationBuilder.RenameColumn(
                name: "ciudad",
                table: "Club",
                newName: "Ciudad");

            migrationBuilder.RenameColumn(
                name: "calle",
                table: "Club",
                newName: "Calle");

            migrationBuilder.RenameColumn(
                name: "altura",
                table: "Club",
                newName: "Altura");

            migrationBuilder.RenameIndex(
                name: "IX_Club_provinciaID",
                table: "Club",
                newName: "IX_Club_ProvinciaID");

            migrationBuilder.AlterColumn<string>(
                name: "Altura",
                table: "Club",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClubID",
                table: "Club",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "NombreClub",
                table: "Club",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SiglaClub",
                table: "Club",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Club",
                table: "Club",
                column: "ClubID");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Provincias_ProvinciaID",
                table: "Club",
                column: "ProvinciaID",
                principalTable: "Provincias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Club_PerfilFK",
                table: "Inscripciones",
                column: "PerfilFK",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Club_TorneoFK",
                table: "Inscripciones",
                column: "TorneoFK",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfiles_Club_clubID",
                table: "Perfiles",
                column: "clubID",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Torneos_Club_ClubFK",
                table: "Torneos",
                column: "ClubFK",
                principalTable: "Club",
                principalColumn: "ClubID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Provincias_ProvinciaID",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Club_PerfilFK",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Club_TorneoFK",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Perfiles_Club_clubID",
                table: "Perfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Torneos_Club_ClubFK",
                table: "Torneos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Club",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "ClubID",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "NombreClub",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "SiglaClub",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Club",
                newName: "telefono");

            migrationBuilder.RenameColumn(
                name: "ProvinciaID",
                table: "Club",
                newName: "provinciaID");

            migrationBuilder.RenameColumn(
                name: "ClubUrl",
                table: "Club",
                newName: "clubUrl");

            migrationBuilder.RenameColumn(
                name: "ClubEmail",
                table: "Club",
                newName: "clubEmail");

            migrationBuilder.RenameColumn(
                name: "Ciudad",
                table: "Club",
                newName: "ciudad");

            migrationBuilder.RenameColumn(
                name: "Calle",
                table: "Club",
                newName: "calle");

            migrationBuilder.RenameColumn(
                name: "Altura",
                table: "Club",
                newName: "altura");

            migrationBuilder.RenameIndex(
                name: "IX_Club_ProvinciaID",
                table: "Club",
                newName: "IX_Club_provinciaID");

            migrationBuilder.AlterColumn<int>(
                name: "altura",
                table: "Club",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Club",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "nombre",
                table: "Club",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sigla",
                table: "Club",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Club",
                table: "Club",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Provincias_provinciaID",
                table: "Club",
                column: "provinciaID",
                principalTable: "Provincias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Club_PerfilFK",
                table: "Inscripciones",
                column: "PerfilFK",
                principalTable: "Club",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Club_TorneoFK",
                table: "Inscripciones",
                column: "TorneoFK",
                principalTable: "Club",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfiles_Club_clubID",
                table: "Perfiles",
                column: "clubID",
                principalTable: "Club",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Torneos_Club_ClubFK",
                table: "Torneos",
                column: "ClubFK",
                principalTable: "Club",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
