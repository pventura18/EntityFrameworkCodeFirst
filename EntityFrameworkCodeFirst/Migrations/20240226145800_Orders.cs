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
                    orderDate = table.Column<DateTime>(nullable: false),
                    requiredDate = table.Column<DateTime>(nullable: false),
                    shippedDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(maxLength: 15, nullable: false),
                    comments = table.Column<string>(nullable: false),
                    customerNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderNumber);
                    table.ForeignKey(
                        name: "FK_orders_customers_customerNumber",
                        column: x => x.customerNumber,
                        principalTable: "customers",
                        principalColumn: "customerNumber",
                        onDelete: ReferentialAction.Restrict);
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
