using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cart.MicroService.Storage.Migrations
{
    /// <inheritdoc />
    public partial class migration_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Cart",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Cart",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Cart",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Cart",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Cart",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cart",
                newName: "userId");
        }
    }
}
