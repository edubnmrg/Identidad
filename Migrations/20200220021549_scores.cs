using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class scores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_Partidos_PartidoId",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Score",
                table: "Score");

            migrationBuilder.RenameTable(
                name: "Score",
                newName: "Scores");

            migrationBuilder.RenameIndex(
                name: "IX_Score_PartidoId",
                table: "Scores",
                newName: "IX_Scores_PartidoId");

            migrationBuilder.AddColumn<int>(
                name: "NumeroSet",
                table: "Scores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Partidos_PartidoId",
                table: "Scores",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "PartidoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Partidos_PartidoId",
                table: "Scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "NumeroSet",
                table: "Scores");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "Score");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_PartidoId",
                table: "Score",
                newName: "IX_Score_PartidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Score",
                table: "Score",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Partidos_PartidoId",
                table: "Score",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "PartidoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
