using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieShop.Backend.Data.Migrations
{
    public partial class ChangenameProductImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productImages_Products_ProductId",
                table: "productImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productImages",
                table: "productImages");

            migrationBuilder.RenameTable(
                name: "productImages",
                newName: "ProductImages");

            migrationBuilder.RenameIndex(
                name: "IX_productImages_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "ProductImageId");

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 1,
                column: "DateUpload",
                value: new DateTime(2022, 2, 25, 14, 47, 59, 523, DateTimeKind.Local).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 2,
                column: "DateUpload",
                value: new DateTime(2022, 2, 25, 14, 47, 59, 524, DateTimeKind.Local).AddTicks(197));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "productImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "productImages",
                newName: "IX_productImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productImages",
                table: "productImages",
                column: "ProductImageId");

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 1,
                column: "DateUpload",
                value: new DateTime(2022, 2, 25, 10, 43, 46, 169, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 2,
                column: "DateUpload",
                value: new DateTime(2022, 2, 25, 10, 43, 46, 170, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.AddForeignKey(
                name: "FK_productImages_Products_ProductId",
                table: "productImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
