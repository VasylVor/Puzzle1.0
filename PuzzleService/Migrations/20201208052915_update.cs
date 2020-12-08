using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleService.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InnerExceprion",
                table: "PuzzleError",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PuzzleError",
                table: "PuzzleError",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PuzzleError",
                table: "PuzzleError");

            migrationBuilder.DropColumn(
                name: "InnerExceprion",
                table: "PuzzleError");
        }
    }
}
