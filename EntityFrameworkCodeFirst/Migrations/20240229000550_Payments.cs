using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class Payments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    customerNumber = table.Column<int>(nullable: false),
                    checkNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.customerNumber);
                    table.ForeignKey(
                        name: "FK_payments_customer_customerNumber",
                        column: x => x.customerNumber,
                        principalTable: "customer",
                        principalColumn: "customerNumber",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");
        }
    }
}
