using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class officeemployeerel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "officeCode",
                table: "employees",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10) CHARACTER SET utf8mb4",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_employees_officeCode",
                table: "employees",
                column: "officeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_offices_officeCode",
                table: "employees",
                column: "officeCode",
                principalTable: "offices",
                principalColumn: "officeCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_offices_officeCode",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_officeCode",
                table: "employees");

            migrationBuilder.AlterColumn<string>(
                name: "officeCode",
                table: "employees",
                type: "varchar(10) CHARACTER SET utf8mb4",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "officeCode1",
                table: "employees",
                type: "varchar(10) CHARACTER SET utf8mb4",
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
    }
}
