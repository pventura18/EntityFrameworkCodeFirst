using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class Customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customerNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customerName = table.Column<string>(type: "varchar(50)", nullable: false),
                    contactLastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    contactFirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    addressLine1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    addressLine2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    city = table.Column<string>(type: "varchar(50)", nullable: false),
                    state = table.Column<string>(type: "varchar(50)", nullable: true),
                    postalCode = table.Column<string>(type: "varchar(15)", nullable: true),
                    country = table.Column<string>(type: "varchar(50)", nullable: false),
                    salesRepEmployeeNumber = table.Column<int>(nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customerNumber);
                    table.ForeignKey(
                        name: "FK_customer_employees_salesRepEmployeeNumber",
                        column: x => x.salesRepEmployeeNumber,
                        principalTable: "employees",
                        principalColumn: "employeeNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_salesRepEmployeeNumber",
                table: "customer",
                column: "salesRepEmployeeNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
