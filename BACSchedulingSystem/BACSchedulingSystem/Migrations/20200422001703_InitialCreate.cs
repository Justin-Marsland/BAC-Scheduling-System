using Microsoft.EntityFrameworkCore.Migrations;

namespace BACSchedulingSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "cost",
                table: "Ingredient",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "RecipeName",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    CookingInstructions = table.Column<string>(nullable: true),
                    GlutenFree = table.Column<bool>(nullable: false),
                    Vegetarian = table.Column<bool>(nullable: false),
                    Vegan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeName",
                table: "Ingredient",
                column: "RecipeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeName",
                table: "Ingredient",
                column: "RecipeName",
                principalTable: "Recipe",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeName",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_RecipeName",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "RecipeName",
                table: "Ingredient");

            migrationBuilder.AlterColumn<decimal>(
                name: "cost",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }
    }
}
