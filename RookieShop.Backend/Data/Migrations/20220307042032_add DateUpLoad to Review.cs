using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieShop.Backend.Data.Migrations
{
    public partial class addDateUpLoadtoReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpload",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 1,
                column: "DateUpload",
                value: new DateTime(2022, 3, 7, 11, 20, 31, 926, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 2,
                column: "DateUpload",
                value: new DateTime(2022, 3, 7, 11, 20, 31, 926, DateTimeKind.Local).AddTicks(9117));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpload",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 1,
                column: "DateUpload",
                value: new DateTime(2022, 3, 7, 11, 3, 48, 778, DateTimeKind.Local).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "Banners",
                keyColumn: "BannerId",
                keyValue: 2,
                column: "DateUpload",
                value: new DateTime(2022, 3, 7, 11, 3, 48, 779, DateTimeKind.Local).AddTicks(4432));
        }
    }
}
