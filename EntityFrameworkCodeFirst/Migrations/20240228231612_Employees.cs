using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class Employees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employeeNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    lastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    extension = table.Column<string>(type: "varchar(10)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    officeCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    reportsTo = table.Column<int>(nullable: true),
                    jobTitle = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employeeNumber);
                    table.ForeignKey(
                        name: "FK_employees_offices_officeCode",
                        column: x => x.officeCode,
                        principalTable: "offices",
                        principalColumn: "officeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_employees_reportsTo",
                        column: x => x.reportsTo,
                        principalTable: "employees",
                        principalColumn: "employeeNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_officeCode",
                table: "employees",
                column: "officeCode");

            migrationBuilder.CreateIndex(
                name: "IX_employees_reportsTo",
                table: "employees",
                column: "reportsTo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
