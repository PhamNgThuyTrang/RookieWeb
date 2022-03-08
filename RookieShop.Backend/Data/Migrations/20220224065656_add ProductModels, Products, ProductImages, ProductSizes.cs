using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieShop.Backend.Data.Migrations
{
    public partial class addProductModelsProductsProductImagesProductSizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductModel_ProductModelId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Product_ProductId",
                table: "ProductImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_Brands_BrandId",
                table: "ProductModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_SubCategories_SubCategoryId",
                table: "ProductModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Product_ProductId",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ProductSize",
                newName: "ProductSizes");

            migrationBuilder.RenameTable(
                name: "ProductModel",
                newName: "ProductModels");

            migrationBuilder.RenameTable(
                name: "ProductImage",
                newName: "productImages");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_ProductId",
                table: "ProductSizes",
                newName: "IX_ProductSizes_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModel_SubCategoryId",
                table: "ProductModels",
                newName: "IX_ProductModels_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModel_BrandId",
                table: "ProductModels",
                newName: "IX_ProductModels_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImage_ProductId",
                table: "productImages",
                newName: "IX_productImages_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductModelId",
                table: "Products",
                newName: "IX_Products_ProductModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSizes",
                table: "ProductSizes",
                column: "ProductSizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModels",
                table: "ProductModels",
                column: "ProductModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productImages",
                table: "productImages",
                column: "ProductImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 1,
                column: "DateUpload",
                value: new DateTime(2022, 2, 24, 13, 56, 56, 27, DateTimeKind.Local).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 2,
                column: "DateUpload",
                value: new DateTime(2022, 2, 24, 13, 56, 56, 27, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.AddForeignKey(
                name: "FK_productImages_Products_ProductId",
                table: "productImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModels_Brands_BrandId",
                table: "ProductModels",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModels_SubCategories_SubCategoryId",
                table: "ProductModels",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductModels_ProductModelId",
                table: "Products",
                column: "ProductModelId",
                principalTable: "ProductModels",
                principalColumn: "ProductModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productImages_Products_ProductId",
                table: "productImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_Brands_BrandId",
                table: "ProductModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_SubCategories_SubCategoryId",
                table: "ProductModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductModels_ProductModelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSizes",
                table: "ProductSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModels",
                table: "ProductModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productImages",
                table: "productImages");

            migrationBuilder.RenameTable(
                name: "ProductSizes",
                newName: "ProductSize");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductModels",
                newName: "ProductModel");

            migrationBuilder.RenameTable(
                name: "productImages",
                newName: "ProductImage");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSize",
                newName: "IX_ProductSize_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductModelId",
                table: "Product",
                newName: "IX_Product_ProductModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModels_SubCategoryId",
                table: "ProductModel",
                newName: "IX_ProductModel_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModels_BrandId",
                table: "ProductModel",
                newName: "IX_ProductModel_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_productImages_ProductId",
                table: "ProductImage",
                newName: "IX_ProductImage_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize",
                column: "ProductSizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "ProductModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage",
                column: "ProductImageId");

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 1,
                column: "DateUpload",
                value: new DateTime(2022, 2, 24, 13, 55, 0, 101, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 2,
                column: "DateUpload",
                value: new DateTime(2022, 2, 24, 13, 55, 0, 102, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductModel_ProductModelId",
                table: "Product",
                column: "ProductModelId",
                principalTable: "ProductModel",
                principalColumn: "ProductModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Product_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_Brands_BrandId",
                table: "ProductModel",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_SubCategories_SubCategoryId",
                table: "ProductModel",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Product_ProductId",
                table: "ProductSize",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
