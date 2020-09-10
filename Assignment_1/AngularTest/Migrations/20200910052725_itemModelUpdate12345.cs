using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularTest.Migrations
{
    public partial class itemModelUpdate12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "itemId",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "itemName",
                table: "shoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "shoppingCartId",
                table: "items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_shoppingCartId",
                table: "items",
                column: "shoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_items_shoppingCarts_shoppingCartId",
                table: "items",
                column: "shoppingCartId",
                principalTable: "shoppingCarts",
                principalColumn: "shoppingCartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_shoppingCarts_shoppingCartId",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_shoppingCartId",
                table: "items");

            migrationBuilder.DropColumn(
                name: "shoppingCartId",
                table: "items");

            migrationBuilder.AddColumn<int>(
                name: "itemId",
                table: "shoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "itemName",
                table: "shoppingCarts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
