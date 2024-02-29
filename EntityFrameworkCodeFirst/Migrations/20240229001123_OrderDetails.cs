using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class OrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderdetails",
                columns: table => new
                {
                    orderNumber = table.Column<int>(nullable: false),
                    productCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    quantityOrdered = table.Column<int>(nullable: false),
                    priceEach = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    orderLineNumber = table.Column<short>(type: "smallint(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetails", x => x.orderNumber);
                    table.ForeignKey(
                        name: "FK_orderdetails_orders_orderNumber",
                        column: x => x.orderNumber,
                        principalTable: "orders",
                        principalColumn: "orderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderdetails_products_productCode",
                        column: x => x.productCode,
                        principalTable: "products",
                        principalColumn: "productCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_productCode",
                table: "orderdetails",
                column: "productCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderdetails");
        }
    }
}
