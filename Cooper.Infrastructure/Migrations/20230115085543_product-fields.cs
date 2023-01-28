using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class productfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCountAsRetail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockCountAsWholesale",
                table: "Products");
        }
    }
}
