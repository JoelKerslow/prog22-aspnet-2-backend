using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddressEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAdresses");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "customerProfileId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_customerProfileId",
                table: "Addresses",
                column: "customerProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CustomerProfiles_customerProfileId",
                table: "Addresses",
                column: "customerProfileId",
                principalTable: "CustomerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CustomerProfiles_customerProfileId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_customerProfileId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "customerProfileId",
                table: "Addresses");

            migrationBuilder.CreateTable(
                name: "AddressEntityCustomerProfileEntity",
                columns: table => new
                {
                    AddressesId = table.Column<int>(type: "int", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEntityCustomerProfileEntity", x => new { x.AddressesId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_AddressEntityCustomerProfileEntity_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressEntityCustomerProfileEntity_CustomerProfiles_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntityCustomerProfileEntity_CustomersId",
                table: "AddressEntityCustomerProfileEntity",
                column: "CustomersId");
        }
    }
}
