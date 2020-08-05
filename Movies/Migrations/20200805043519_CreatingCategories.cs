using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class CreatingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryCategoriesId",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoriesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CategoryCategoriesId",
                table: "Movie",
                column: "CategoryCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Categories_CategoryCategoriesId",
                table: "Movie",
                column: "CategoryCategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Categories_CategoryCategoriesId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CategoryCategoriesId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CategoryCategoriesId",
                table: "Movie");
        }
    }
}
