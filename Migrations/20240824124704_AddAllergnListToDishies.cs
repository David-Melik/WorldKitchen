using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldKitchen.Migrations
{
    /// <inheritdoc />
    public partial class AddAllergnListToDishies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllergnList",
                table: "Dishies",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllergnList",
                table: "Dishies");
        }
    }
}
