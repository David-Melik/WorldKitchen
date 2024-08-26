using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldKitchen.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Flag = table.Column<string>(type: "TEXT", nullable: true),
                    Map = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Traduction = table.Column<string>(type: "TEXT", nullable: true),
                    VoiceName = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePreview = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<int>(type: "INTEGER", nullable: true),
                    Video = table.Column<string>(type: "TEXT", nullable: true),
                    Svg1 = table.Column<string>(type: "TEXT", nullable: true),
                    Svg2 = table.Column<string>(type: "TEXT", nullable: true),
                    Svg3 = table.Column<string>(type: "TEXT", nullable: true),
                    Allergen = table.Column<bool>(type: "INTEGER", nullable: false),
                    IngredientList = table.Column<string>(type: "TEXT", nullable: true),
                    StepList = table.Column<string>(type: "TEXT", nullable: true),
                    Nutrition = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Dishies");
        }
    }
}
