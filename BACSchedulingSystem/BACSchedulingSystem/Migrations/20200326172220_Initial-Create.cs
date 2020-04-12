using System;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

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
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    ingredientList = table.Column<List<BACSchedulingSystem.Models.Ingredient>>(nullable: false),
                    cookingInstruction = table.Column<string>(nullable: false),
                    peopleFed = table.Column<int>(nullable: true),
                    glutenFree = table.Column<bool>(nullable: false),
                    vegetarian = table.Column<bool>(nullable: false),
                    vegan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
