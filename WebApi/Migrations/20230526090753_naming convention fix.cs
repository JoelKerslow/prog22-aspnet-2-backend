using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class namingconventionfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CustomerProfiles_customerProfileId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "customerProfileId",
                table: "Addresses",
                newName: "CustomerProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_customerProfileId",
                table: "Addresses",
                newName: "IX_Addresses_CustomerProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CustomerProfiles_CustomerProfileId",
                table: "Addresses",
                column: "CustomerProfileId",
                principalTable: "CustomerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CustomerProfiles_CustomerProfileId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CustomerProfileId",
                table: "Addresses",
                newName: "customerProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CustomerProfileId",
                table: "Addresses",
                newName: "IX_Addresses_customerProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CustomerProfiles_customerProfileId",
                table: "Addresses",
                column: "customerProfileId",
                principalTable: "CustomerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
