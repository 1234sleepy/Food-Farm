using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Order.MicroService.Storage.Migrations
{
    /// <inheritdoc />
    public partial class addOrderStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("33060dbf-ff02-43ef-90f2-66110b7a142e"), "InProgress" },
                    { new Guid("61e0052b-ec57-410d-80e9-88eaa2fac5c7"), "Completed" },
                    { new Guid("e0add828-035e-4fed-a27f-d31ae22ad9c2"), "Created" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("33060dbf-ff02-43ef-90f2-66110b7a142e"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("61e0052b-ec57-410d-80e9-88eaa2fac5c7"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("e0add828-035e-4fed-a27f-d31ae22ad9c2"));
        }
    }
}
