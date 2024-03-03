using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class fixedcomposedPrimaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_payments",
                table: "payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetails",
                table: "orderdetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_payments",
                table: "payments",
                columns: new[] { "customerNumber", "checkNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetails",
                table: "orderdetails",
                columns: new[] { "orderNumber", "productCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_payments",
                table: "payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetails",
                table: "orderdetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_payments",
                table: "payments",
                column: "customerNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetails",
                table: "orderdetails",
                column: "orderNumber");
        }
    }
}
