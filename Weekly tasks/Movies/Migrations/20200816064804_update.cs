using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategoryViewModel_Categories_CategoryId",
                table: "MovieCategoryViewModel");

            migrationBuilder.DropIndex(
                name: "IX_MovieCategoryViewModel_CategoryId",
                table: "MovieCategoryViewModel");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MovieCategoryViewModel");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MovieCategoryViewModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MovieCategoryViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "MovieCategoryViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategoryViewModel_CategoryId",
                table: "MovieCategoryViewModel",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategoryViewModel_Categories_CategoryId",
                table: "MovieCategoryViewModel",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
