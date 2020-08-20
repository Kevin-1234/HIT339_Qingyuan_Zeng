using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class MovieDropDown1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Categories_CategoryCategoriesId",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_CategoryCategoriesId",
                table: "Movies",
                newName: "IX_Movies_CategoryCategoriesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoryCategoriesId",
                table: "Movies",
                column: "CategoryCategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoryCategoriesId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CategoryCategoriesId",
                table: "Movie",
                newName: "IX_Movie_CategoryCategoriesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Categories_CategoryCategoriesId",
                table: "Movie",
                column: "CategoryCategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
