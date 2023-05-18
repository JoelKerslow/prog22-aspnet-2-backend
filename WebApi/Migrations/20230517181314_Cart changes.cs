using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Cartchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCarts_CustomerProfiles_CustomerId",
                table: "CustomerCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerWishlists_CustomerProfiles_CustomerId",
                table: "CustomerWishlists");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductWishlists_CustomerWishlists_CustomerWishlistId",
                table: "ProductWishlists");

            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerWishlists",
                table: "CustomerWishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCarts",
                table: "CustomerCarts");

            migrationBuilder.RenameTable(
                name: "CustomerWishlists",
                newName: "Wishlists");

            migrationBuilder.RenameTable(
                name: "CustomerCarts",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerWishlists_CustomerId",
                table: "Wishlists",
                newName: "IX_Wishlists_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Carts",
                newName: "CustomerProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerCarts_CustomerId",
                table: "Carts",
                newName: "IX_Carts_CustomerProfileId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PromoCodeId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_PromoCodeId",
                table: "Carts",
                column: "PromoCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_CustomerProfiles_CustomerProfileId",
                table: "Carts",
                column: "CustomerProfileId",
                principalTable: "CustomerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_PromoCodes_PromoCodeId",
                table: "Carts",
                column: "PromoCodeId",
                principalTable: "PromoCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWishlists_Wishlists_CustomerWishlistId",
                table: "ProductWishlists",
                column: "CustomerWishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_CustomerProfiles_CustomerId",
                table: "Wishlists",
                column: "CustomerId",
                principalTable: "CustomerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_CustomerProfiles_CustomerProfileId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductEntityId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_PromoCodes_PromoCodeId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductWishlists_Wishlists_CustomerWishlistId",
                table: "ProductWishlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_CustomerProfiles_CustomerId",
                table: "Wishlists");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ProductEntityId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_PromoCodeId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ProductEntityId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PromoCodeId",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Wishlists",
                newName: "CustomerWishlists");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "CustomerCarts");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_CustomerId",
                table: "CustomerWishlists",
                newName: "IX_CustomerWishlists_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerProfileId",
                table: "CustomerCarts",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_CustomerProfileId",
                table: "CustomerCarts",
                newName: "IX_CustomerCarts_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerWishlists",
                table: "CustomerWishlists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCarts",
                table: "CustomerCarts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    CustomerCartsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.CustomerCartsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CartProducts_CustomerCarts_CustomerCartsId",
                        column: x => x.CustomerCartsId,
                        principalTable: "CustomerCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductsId",
                table: "CartProducts",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCarts_CustomerProfiles_CustomerId",
                table: "CustomerCarts",
                column: "CustomerId",
                principalTable: "CustomerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerWishlists_CustomerProfiles_CustomerId",
                table: "CustomerWishlists",
                column: "CustomerId",
                principalTable: "CustomerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWishlists_CustomerWishlists_CustomerWishlistId",
                table: "ProductWishlists",
                column: "CustomerWishlistId",
                principalTable: "CustomerWishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
