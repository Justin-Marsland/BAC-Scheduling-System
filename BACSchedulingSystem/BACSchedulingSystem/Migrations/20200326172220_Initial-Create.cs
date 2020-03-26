using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BACSchedulingSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    expDate = table.Column<DateTime>(nullable: false),
                    vendor = table.Column<string>(nullable: true),
                    amount = table.Column<short>(nullable: false),
                    cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");
        }
    }
}
