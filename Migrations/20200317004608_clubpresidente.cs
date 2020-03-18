using Microsoft.EntityFrameworkCore.Migrations;

namespace Identidad.Migrations
{
    public partial class clubpresidente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            





            migrationBuilder.AddColumn<int>(
                name: "PresidenteID",
                table: "Club",
                nullable: false,
                defaultValue: 0);

           

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            





            migrationBuilder.DropColumn(
                name: "PresidenteID",
                table: "Club");

           
           

          

            
           
        }
    }
}
