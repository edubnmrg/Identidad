using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class cjuegoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriasJugadores_Club_CategoriaFK",
                table: "CategoriasJugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriasJugadores_Club_JuegoFK",
                table: "CategoriasJugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriasJugadores_Club_PerfilFK",
                table: "CategoriasJugadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Juegoes",
                table: "Juegoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriasJugadores",
                table: "CategoriasJugadores");

            migrationBuilder.DropColumn(
                name: "InscripcionID",
                table: "CategoriasJugadores");

            migrationBuilder.AlterColumn<string>(
                name: "nombreJuego",
                table: "Juegoes",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<int>(
                name: "JuegoID",
                table: "Juegoes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaJugadorID",
                table: "CategoriasJugadores",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Juegoes",
                table: "Juegoes",
                column: "JuegoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriasJugadores",
                table: "CategoriasJugadores",
                column: "CategoriaJugadorID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriasJugadores_Categorias_CategoriaFK",
                table: "CategoriasJugadores",
                column: "CategoriaFK",
                principalTable: "Categorias",
                principalColumn: "categoriaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriasJugadores_Juegoes_JuegoFK",
                table: "CategoriasJugadores",
                column: "JuegoFK",
                principalTable: "Juegoes",
                principalColumn: "JuegoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriasJugadores_Perfiles_PerfilFK",
                table: "CategoriasJugadores",
                column: "PerfilFK",
                principalTable: "Perfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriasJugadores_Categorias_CategoriaFK",
                table: "CategoriasJugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriasJugadores_Juegoes_JuegoFK",
                table: "CategoriasJugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriasJugadores_Perfiles_PerfilFK",
                table: "CategoriasJugadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Juegoes",
                table: "Juegoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriasJugadores",
                table: "CategoriasJugadores");

            migrationBuilder.DropColumn(
                name: "JuegoID",
                table: "Juegoes");

            migrationBuilder.DropColumn(
                name: "CategoriaJugadorID",
                table: "CategoriasJugadores");

            migrationBuilder.AlterColumn<string>(
                name: "nombreJuego",
                table: "Juegoes",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InscripcionID",
                table: "CategoriasJugadores",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Juegoes",
                table: "Juegoes",
                column: "nombreJuego");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriasJugadores",
                table: "CategoriasJugadores",
                column: "InscripcionID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriasJugadores_Club_CategoriaFK",
                table: "CategoriasJugadores",
                column: "CategoriaFK",
                principalTable: "Club",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriasJugadores_Club_JuegoFK",
                table: "CategoriasJugadores",
                column: "JuegoFK",
                principalTable: "Club",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriasJugadores_Club_PerfilFK",
                table: "CategoriasJugadores",
                column: "PerfilFK",
                principalTable: "Club",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
