using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class employeesofficesrel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "officeCode1",
                table: "employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_officeCode1",
                table: "employees",
                column: "officeCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_offices_officeCode1",
                table: "employees",
                column: "officeCode1",
                principalTable: "offices",
                principalColumn: "officeCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_offices_officeCode1",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_officeCode1",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "officeCode1",
                table: "employees");
        }
    }
}
