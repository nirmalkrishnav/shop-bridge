using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridge.Infrastructure.DataAccess.Migrations
{
    public partial class categoryinentroy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Inventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Inventory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Inventory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Inventory",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Inventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Inventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Inventory",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "Code" },
                values: new object[,]
                {
                    { 1, "Home Improvement", "HI" },
                    { 2, "Electronics", "ELEC" }
                });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "IsActive", "Name", "Price", "Quantity", "Status", "Unit" },
                values: new object[] { 1, "Small house plant", true, "House plant 1", 259.0, 200, 1, "INR" });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "IsActive", "Name", "Price", "Quantity", "Status", "Unit" },
                values: new object[] { 2, "Noise cancelling microphone", true, "Microphone", 599.99000000000001, 500, 1, "INR" });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "CategoryId", "Description", "IsActive", "Name", "Price", "Quantity", "Status", "Unit" },
                values: new object[] { 3, 1, "Rugged door mat", true, "Door mat", 99.0, 500, 1, "INR" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CategoryId",
                table: "Inventory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Category_CategoryId",
                table: "Inventory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Category_CategoryId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_CategoryId",
                table: "Inventory");

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Inventory");

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
    }
}
