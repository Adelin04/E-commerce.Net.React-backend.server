using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRelationshipsProductCategoryProductTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryProducts_FK_CategoryProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FK_CategoryProductId",
                table: "Products");

            migrationBuilder.AddColumn<long>(
                name: "CategoryProductId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryProductId",
                table: "Products",
                column: "CategoryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductId",
                table: "Products",
                column: "CategoryProductId",
                principalTable: "CategoryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryProductId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FK_CategoryProductId",
                table: "Products",
                column: "FK_CategoryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryProducts_FK_CategoryProductId",
                table: "Products",
                column: "FK_CategoryProductId",
                principalTable: "CategoryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
