using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class MovieDropDown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Categories_CategoryCategoriesId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryCategoriesId",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Categories_CategoryCategoriesId",
                table: "Movie",
                column: "CategoryCategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Categories_CategoryCategoriesId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryCategoriesId",
                table: "Movie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Categories_CategoryCategoriesId",
                table: "Movie",
                column: "CategoryCategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
