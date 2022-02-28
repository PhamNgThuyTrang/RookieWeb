using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieShop.Backend.Data.Migrations
{
    public partial class AddisdeletedtoProductImagecsandProductSizecs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductSizes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "productImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "productImages");

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
        }
    }
}
