using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    orderDate = table.Column<DateTime>(type: "date", nullable: false),
                    requiredDate = table.Column<DateTime>(type: "date", nullable: false),
                    shippedDate = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<string>(type: "varchar(15)", nullable: false),
                    comments = table.Column<string>(type: "text", nullable: true),
                    customerNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderNumber);
                    table.ForeignKey(
                        name: "FK_orders_customer_customerNumber",
                        column: x => x.customerNumber,
                        principalTable: "customer",
                        principalColumn: "customerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_customerNumber",
                table: "orders",
                column: "customerNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
