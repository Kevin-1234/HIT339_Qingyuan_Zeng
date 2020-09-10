using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularTest.Migrations
{
    public partial class itemModelUpdate123456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "shoppingCartItems",
                columns: table => new
                {
                    shoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(nullable: false),
                    shoppingCartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCartItems", x => x.shoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_shoppingCartItems_items_itemId",
                        column: x => x.itemId,
                        principalTable: "items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shoppingCartItems_shoppingCarts_shoppingCartId",
                        column: x => x.shoppingCartId,
                        principalTable: "shoppingCarts",
                        principalColumn: "shoppingCartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCartItems_itemId",
                table: "shoppingCartItems",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCartItems_shoppingCartId",
                table: "shoppingCartItems",
                column: "shoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoppingCartItems");

            migrationBuilder.AddColumn<int>(
                name: "shoppingCartId",
                table: "items",
                type: "int",
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
    }
}
