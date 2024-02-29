using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    productName = table.Column<string>(type: "varchar(70)", nullable: false),
                    productLine = table.Column<string>(type: "varchar(50)", nullable: false),
                    productScale = table.Column<string>(type: "varchar(10)", nullable: false),
                    productVendor = table.Column<string>(type: "varchar(50)", nullable: false),
                    productDescription = table.Column<string>(type: "text", nullable: false),
                    quantityInStock = table.Column<short>(type: "smallint(6)", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MSRP = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productCode);
                    table.ForeignKey(
                        name: "FK_products_productlines_productLine",
                        column: x => x.productLine,
                        principalTable: "productlines",
                        principalColumn: "productLine",
                        onDelete: ReferentialAction.Cascade);
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
        }
    }
}
