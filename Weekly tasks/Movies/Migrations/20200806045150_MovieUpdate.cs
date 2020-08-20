using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class MovieUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "code",
                table: "Categories",
                newName: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Categories",
                newName: "code");
        }
    }
}
