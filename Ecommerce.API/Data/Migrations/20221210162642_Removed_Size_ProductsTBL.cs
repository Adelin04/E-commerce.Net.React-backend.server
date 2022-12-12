using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSizeProductsTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SizeId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
