using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieShop.Backend.Data.Migrations
{
    public partial class seedcategorydata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 1,
                column: "DateUpload",
                value: new DateTime(2022, 2, 24, 13, 54, 3, 191, DateTimeKind.Local).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 2,
                column: "DateUpload",
                value: new DateTime(2022, 2, 24, 13, 54, 3, 192, DateTimeKind.Local).AddTicks(1706));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "ImagePath", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Men" },
                    { 2, null, false, "Adidas" },
                    { 3, null, false, "Kid" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 1,
                column: "DateUpload",
                value: new DateTime(2022, 2, 24, 13, 52, 31, 315, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 2,
                column: "DateUpload",
                value: new DateTime(2022, 2, 24, 13, 52, 31, 316, DateTimeKind.Local).AddTicks(4436));
        }
    }
}
