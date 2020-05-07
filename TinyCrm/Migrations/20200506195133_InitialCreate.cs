using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TinyCrm.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    VatNumber = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    TotalGross = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategory = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "Created", "Dob", "Email", "FirstName", "IsActive", "LastName", "Phone", "TotalGross", "VatNumber" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TestCust1Name", false, "TestCust1LastName", null, 0m, "123456789" },
                    { 2, null, new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TestCust2Name", false, "TestCust2LastName", null, 0m, "987654321" },
                    { 3, null, new DateTime(2020, 5, 6, 22, 51, 32, 696, DateTimeKind.Local).AddTicks(2986), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TestCust3Name", false, "TestCust3LastName", null, 0m, "123654789" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Description", "Name", "Price", "ProductCategory" },
                values: new object[,]
                {
                    { 1, null, "TestProd1", 20.0m, "games" },
                    { 2, null, "TestProd2", 40.0m, "games" },
                    { 3, null, "TestProd3", 150.0m, "technology" },
                    { 4, null, "TestProd4", 60.0m, "software" },
                    { 5, null, "TestProd5", 45.0m, "gadgets" },
                    { 6, null, "TestProd6", 100.0m, "hardware" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
