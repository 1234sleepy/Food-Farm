using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Storage.Migrations
{
    /// <inheritdoc />
    public partial class addOrderStatusField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("33060dbf-ff02-43ef-90f2-66110b7a142e"));

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("33060dbf-ff02-43ef-90f2-66110b7a142e"), "InProgress" },
                    { new Guid("61e0052b-ec57-410d-80e9-88eaa2fac5c7"), "Completed" },
                    { new Guid("e0add828-035e-4fed-a27f-d31ae22ad9c2"), "Created" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatus_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "OrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatus_StatusId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Orders");
        }
    }
}
