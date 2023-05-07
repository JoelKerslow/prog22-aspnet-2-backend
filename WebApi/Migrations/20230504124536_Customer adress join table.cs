using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Customeradressjointable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProfiles_Addresses_AddressId",
                table: "CustomerProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProfiles_Addresses_ShippingAddressId",
                table: "CustomerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_CustomerProfiles_AddressId",
                table: "CustomerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_CustomerProfiles_ShippingAddressId",
                table: "CustomerProfiles");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "CustomerProfiles");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "CustomerProfiles");

            migrationBuilder.CreateTable(
                name: "CustomerAdresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAdresses", x => new { x.AddressId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerAdresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAdresses_CustomerProfiles_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdresses_CustomerId",
                table: "CustomerAdresses",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAdresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "CustomerProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressId",
                table: "CustomerProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_AddressId",
                table: "CustomerProfiles",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_ShippingAddressId",
                table: "CustomerProfiles",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProfiles_Addresses_AddressId",
                table: "CustomerProfiles",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProfiles_Addresses_ShippingAddressId",
                table: "CustomerProfiles",
                column: "ShippingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
