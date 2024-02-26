using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customerName = table.Column<string>(maxLength: 50, nullable: false),
                    contactLastName = table.Column<string>(maxLength: 50, nullable: false),
                    contactFirstName = table.Column<string>(maxLength: 50, nullable: false),
                    phone = table.Column<string>(maxLength: 50, nullable: false),
                    addressLine1 = table.Column<string>(maxLength: 50, nullable: false),
                    addressLine2 = table.Column<string>(maxLength: 50, nullable: false),
                    city = table.Column<string>(maxLength: 50, nullable: false),
                    state = table.Column<string>(maxLength: 50, nullable: false),
                    postalCode = table.Column<string>(maxLength: 15, nullable: false),
                    country = table.Column<string>(maxLength: 50, nullable: false),
                    creditLimit = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    employeeNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerNumber);
                    table.ForeignKey(
                        name: "FK_customers_employees_employeeNumber",
                        column: x => x.employeeNumber,
                        principalTable: "employees",
                        principalColumn: "employeeNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_employeeNumber",
                table: "customers",
                column: "employeeNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
