using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storage.Migrations
{
    /// <inheritdoc />
    public partial class fixOrderItem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityLimit",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityLimit",
                table: "OrderItems");
        }
    }
}
