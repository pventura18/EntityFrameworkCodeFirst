using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst.Migrations
{
    public partial class ProductLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productlines",
                columns: table => new
                {
                    productLine = table.Column<string>(type: "varchar(50)", nullable: false),
                    textDescription = table.Column<string>(type: "varchar(4000)", nullable: true),
                    htmlDescription = table.Column<string>(type: "mediumtext", nullable: true),
                    image = table.Column<byte[]>(type: "mediumblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productlines", x => x.productLine);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productlines");
        }
    }
}
