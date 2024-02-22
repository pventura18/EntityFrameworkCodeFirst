using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class productsproductlinesrel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productlines",
                columns: table => new
                {
                    productLine = table.Column<string>(maxLength: 50, nullable: false),
                    textDescription = table.Column<string>(maxLength: 4000, nullable: false),
                    htmlDescription = table.Column<string>(nullable: false),
                    image = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productlines", x => x.productLine);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productCode = table.Column<string>(maxLength: 15, nullable: false),
                    productName = table.Column<string>(maxLength: 70, nullable: false),
                    productScale = table.Column<string>(maxLength: 10, nullable: false),
                    productVendor = table.Column<string>(maxLength: 50, nullable: false),
                    productDescription = table.Column<string>(nullable: false),
                    quantityInStock = table.Column<short>(type: "smallint", nullable: false),
                    buyPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    MSRP = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    productLine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productCode);
                    table.ForeignKey(
                        name: "FK_products_productlines_productLine",
                        column: x => x.productLine,
                        principalTable: "productlines",
                        principalColumn: "productLine",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_productLine",
                table: "products",
                column: "productLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "productlines");
        }
    }
}
