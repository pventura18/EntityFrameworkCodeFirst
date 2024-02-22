using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class reportsTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reportsTo",
                table: "employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_reportsTo",
                table: "employees",
                column: "reportsTo");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_employees_reportsTo",
                table: "employees",
                column: "reportsTo",
                principalTable: "employees",
                principalColumn: "employeeNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_employees_reportsTo",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_reportsTo",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "reportsTo",
                table: "employees");
        }
    }
}
