using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class Office : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "offices",
                columns: table => new
                {
                    officeCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    city = table.Column<string>(type: "varchar(50)", nullable: false),
                    phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    addressLine1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    addressLine2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    state = table.Column<string>(type: "varchar(50)", nullable: true),
                    country = table.Column<string>(type: "varchar(50)", nullable: false),
                    postalCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    territory = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offices", x => x.officeCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "offices");
        }
    }
}
