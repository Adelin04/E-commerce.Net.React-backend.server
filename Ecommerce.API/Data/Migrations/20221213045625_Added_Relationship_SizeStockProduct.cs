using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationshipSizeStockProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeStocks_Products_ProductId",
                table: "SizeStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeStocks_Sizes_SizeId",
                table: "SizeStocks");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "SizeStocks",
                newName: "FK_SizeId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "SizeStocks",
                newName: "FK_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SizeStocks_SizeId",
                table: "SizeStocks",
                newName: "IX_SizeStocks_FK_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_SizeStocks_ProductId",
                table: "SizeStocks",
                newName: "IX_SizeStocks_FK_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeStocks_Products_FK_ProductId",
                table: "SizeStocks",
                column: "FK_ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeStocks_Sizes_FK_SizeId",
                table: "SizeStocks",
                column: "FK_SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeStocks_Products_FK_ProductId",
                table: "SizeStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeStocks_Sizes_FK_SizeId",
                table: "SizeStocks");

            migrationBuilder.RenameColumn(
                name: "FK_SizeId",
                table: "SizeStocks",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "FK_ProductId",
                table: "SizeStocks",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SizeStocks_FK_SizeId",
                table: "SizeStocks",
                newName: "IX_SizeStocks_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_SizeStocks_FK_ProductId",
                table: "SizeStocks",
                newName: "IX_SizeStocks_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeStocks_Products_ProductId",
                table: "SizeStocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeStocks_Sizes_SizeId",
                table: "SizeStocks",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
