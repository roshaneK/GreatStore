using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreatStore.Data.Migrations
{
    public partial class Itemtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Units = table.Column<long>(nullable: false),
                    PriceByUnit = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
