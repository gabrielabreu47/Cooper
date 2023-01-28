using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class billphone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RNC",
                table: "Bills",
                newName: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Bills",
                newName: "RNC");
        }
    }
}
