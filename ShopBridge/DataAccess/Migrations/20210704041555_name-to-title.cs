using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridge.Infrastructure.DataAccess.Migrations
{
    public partial class nametotitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Inventory",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a81f0897-92ef-495d-8208-0023c7e87c89");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "949d854f-3b69-4cbf-a6b1-9325c13d3884");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Water bottle");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Fountain Pen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a9006003-36c6-448d-b6d0-0de3fc591f72");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "70a596cb-f6d1-4fd7-9386-acc6b576d9e2");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Water bottle");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Fountain Pen");
        }
    }
}
