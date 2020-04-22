using Microsoft.EntityFrameworkCore.Migrations;

namespace BACSchedulingSystem.Migrations
{
    public partial class _2ndCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Recipe",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Recipe");
        }
    }
}
