using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieShop.Backend.Data.Migrations
{
    public partial class seedbannerdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "BannerId", "DateUpload", "ImagePath", "IsDeleted", "Name" },
                values: new object[] { 1, new DateTime(2022, 2, 24, 13, 52, 31, 315, DateTimeKind.Local).AddTicks(8946), "5ecc6547-f3c2-4b38-8528-c2e4dc5c0751.jpeg", false, "Women's Shoes, Clothing & Accessories" });

            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "BannerId", "DateUpload", "ImagePath", "IsDeleted", "Name" },
                values: new object[] { 2, new DateTime(2022, 2, 24, 13, 52, 31, 316, DateTimeKind.Local).AddTicks(4436), "f6a57e16-2956-435e-843a-4ebd1ce0fb1f.jpeg", false, "Everlasting Love Pack: Available from 18 February" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 2);
        }
    }
}
