using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridge.Infrastructure.DataAccess.Migrations
{
    public partial class createdmodifieddates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Inventory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Inventory",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e62b0aed-ed3d-47e1-9061-f298fd5abb84");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6e080767-c4df-442e-997a-0e1c368039e6");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "10x Bass Wired Microphone");

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name", "Price", "Quantity", "Status", "Unit" },
                values: new object[,]
                {
                    { 4, 1, null, "10x10 array LED", true, null, "LED Lamp", 249.0, 1000, 2, "INR" },
                    { 5, 1, null, "Rose flavor room freshner", true, null, "Rose Room freshner", 149.0, 1000, 2, "INR" },
                    { 6, 2, null, "500 GB USB Stick", true, null, "Kaaza USB Stick - 500 GB", 999.0, 400, 1, "INR" },
                    { 7, 2, null, "1TB USB Stick", true, null, "Kaaza USB Stick - 1 TB", 1899.0, 200, 1, "INR" },
                    { 8, 2, null, "TWS Earphones", true, null, "TWS Earphones", 1899.0, 50, 1, "INR" },
                    { 9, 2, null, "First copy Cherry Blue keys", true, null, "Rezer Mechanical feel keyboard", 4999.0, 50, 1, "INR" },
                    { 10, 2, null, "Original Cherry mx Blue keys", true, null, "Razor Mechanical keyboard", 9999.0, 10, 1, "INR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Inventory");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c41eecfb-908c-4504-96cb-d4acc05d0184");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b777a7b8-4ccf-47b9-8906-271ebd7f660a");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Microphone");
        }
    }
}
