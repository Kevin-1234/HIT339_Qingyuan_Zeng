using Microsoft.EntityFrameworkCore.Migrations;

namespace e_shop_Qingyuan_zeng_s316740.Migrations
{
    public partial class modelsUpdate01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shoppingCarts",
                columns: table => new
                {
                    shoppingCartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCarts", x => x.shoppingCartId);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    itemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(nullable: true),
                    itemPrice = table.Column<int>(nullable: false),
                    itemType = table.Column<string>(nullable: true),
                    itemImage = table.Column<string>(nullable: true),
                    userEmail = table.Column<string>(nullable: true),
                    shoppingCartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_items_shoppingCarts_shoppingCartId",
                        column: x => x.shoppingCartId,
                        principalTable: "shoppingCarts",
                        principalColumn: "shoppingCartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_shoppingCartId",
                table: "items",
                column: "shoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "shoppingCarts");
        }
    }
}
