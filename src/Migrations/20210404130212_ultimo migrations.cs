using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cart_api.Migrations
{
    public partial class ultimomigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartGuid", "CreateTime", "VariantId" },
                values: new object[] { 1, new Guid("de8adcfa-a172-4e41-9139-35d0b7a3b58f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Guid", "CreateTime", "CustomerId", "Status" },
                values: new object[] { new Guid("de8adcfa-a172-4e41-9139-35d0b7a3b58f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "OPEN" });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "Id", "Barcode", "CreateTime", "IsActive", "StockQuantity" },
                values: new object[] { 1, "foobarcode", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Variants");
        }
    }
}
