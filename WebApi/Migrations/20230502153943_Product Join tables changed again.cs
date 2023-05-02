using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ProductJointableschangedagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CustomerCarts_CartEntityId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CustomerWishlists_WishlistId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CartEntityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WishlistId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WishlistId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CartEntityProductEntity",
                columns: table => new
                {
                    CustomerCartsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartEntityProductEntity", x => new { x.CustomerCartsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CartEntityProductEntity_CustomerCarts_CustomerCartsId",
                        column: x => x.CustomerCartsId,
                        principalTable: "CustomerCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartEntityProductEntity_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntityWishlistEntity",
                columns: table => new
                {
                    CustomerWishlistsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntityWishlistEntity", x => new { x.CustomerWishlistsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductEntityWishlistEntity_CustomerWishlists_CustomerWishlistsId",
                        column: x => x.CustomerWishlistsId,
                        principalTable: "CustomerWishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductEntityWishlistEntity_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartEntityProductEntity_ProductsId",
                table: "CartEntityProductEntity",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntityWishlistEntity_ProductsId",
                table: "ProductEntityWishlistEntity",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartEntityProductEntity");

            migrationBuilder.DropTable(
                name: "ProductEntityWishlistEntity");

            migrationBuilder.AddColumn<int>(
                name: "CartEntityId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WishlistId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartEntityId",
                table: "Products",
                column: "CartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WishlistId",
                table: "Products",
                column: "WishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CustomerCarts_CartEntityId",
                table: "Products",
                column: "CartEntityId",
                principalTable: "CustomerCarts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CustomerWishlists_WishlistId",
                table: "Products",
                column: "WishlistId",
                principalTable: "CustomerWishlists",
                principalColumn: "Id");
        }
    }
}
