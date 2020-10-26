using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleService.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puzzle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IdImage = table.Column<int>(nullable: true),
                    Puzzle = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puzzle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Puzzle",
                        column: x => x.IdImage,
                        principalTable: "Puzzle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PuzzleError",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    MethodName = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Message = table.Column<string>(unicode: false, nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puzzle_IdImage",
                table: "Puzzle",
                column: "IdImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Puzzle");

            migrationBuilder.DropTable(
                name: "PuzzleError");
        }
    }
}
