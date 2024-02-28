using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class ProductLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductLines",
                columns: table => new
                {
                    ProductLine = table.Column<string>(maxLength: 50, nullable: false),
                    TextDescription = table.Column<string>(maxLength: 4000, nullable: false),
                    HtmlDescription = table.Column<string>(type: "MEDIUMTEXT", nullable: false),
                    Imatge = table.Column<byte[]>(type: "MEDIUMBLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLines", x => x.ProductLine);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLines");
        }
    }
}
