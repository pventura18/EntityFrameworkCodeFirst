using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class officesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "offices",
                columns: table => new
                {
                    officeCode = table.Column<string>(maxLength: 10, nullable: false),
                    city = table.Column<string>(maxLength: 50, nullable: false),
                    phone = table.Column<string>(maxLength: 50, nullable: false),
                    addressLine1 = table.Column<string>(maxLength: 50, nullable: false),
                    addressLine2 = table.Column<string>(maxLength: 50, nullable: false),
                    state = table.Column<string>(maxLength: 50, nullable: false),
                    country = table.Column<string>(maxLength: 50, nullable: false),
                    postalCode = table.Column<string>(maxLength: 15, nullable: false),
                    territory = table.Column<string>(maxLength: 10, nullable: false)
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
