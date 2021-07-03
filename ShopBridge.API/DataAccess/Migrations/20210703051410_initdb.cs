using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridge.Infrastructure.DataAccess.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Water bottle" });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Fountain Pen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
