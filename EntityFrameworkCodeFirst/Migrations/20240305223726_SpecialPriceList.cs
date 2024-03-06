using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class SpecialPriceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "specialpricelist",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false),
                    productCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialpricelist", x => new { x.productCode, x.customerId });
                    table.ForeignKey(
                        name: "FK_specialpricelist_customer_customerId",
                        column: x => x.customerId,
                        principalTable: "customer",
                        principalColumn: "customerNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_specialpricelist_products_productCode",
                        column: x => x.productCode,
                        principalTable: "products",
                        principalColumn: "productCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_specialpricelist_customerId",
                table: "specialpricelist",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "specialpricelist");
        }
    }
}
