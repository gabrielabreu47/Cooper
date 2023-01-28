using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class productstockdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCountAsRetail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockCountAsWholesale",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductStockDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    StockCountAsRetail = table.Column<int>(type: "INTEGER", nullable: false),
                    StockCountAsWholesale = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStockDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStockDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockDetails_ProductId",
                table: "ProductStockDetails",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStockDetails");

            migrationBuilder.AddColumn<int>(
                name: "StockCountAsRetail",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockCountAsWholesale",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
