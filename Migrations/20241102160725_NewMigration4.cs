using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldKitchen.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nutrition",
                table: "Dish",
                newName: "NutritionList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NutritionList",
                table: "Dish",
                newName: "Nutrition");
        }
    }
}
