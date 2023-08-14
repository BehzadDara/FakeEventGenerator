using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FakeEventGenerator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnvironmentVariable",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentVariable", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "PartOfHouse",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Coordinate1X = table.Column<int>(type: "int", nullable: false),
                    Coordinate1Y = table.Column<int>(type: "int", nullable: false),
                    Coordinate2X = table.Column<int>(type: "int", nullable: false),
                    Coordinate2Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOfHouse", x => x.Type);
                });

            migrationBuilder.InsertData(
                table: "EnvironmentVariable",
                columns: new[] { "Type", "Value" },
                values: new object[,]
                {
                    { "Degree", 20 },
                    { "Humidity", 20 },
                    { "Light", 10 },
                    { "Sound", 30 }
                });

            migrationBuilder.InsertData(
                table: "PartOfHouse",
                columns: new[] { "Type", "Coordinate1X", "Coordinate1Y", "Coordinate2X", "Coordinate2Y" },
                values: new object[,]
                {
                    { "Balcony", 0, 80, 100, 100 },
                    { "Bathroom", 80, 0, 100, 30 },
                    { "Bedroom1", 0, 50, 50, 80 },
                    { "Bedroom2", 50, 50, 100, 80 },
                    { "Corridor", 0, 30, 100, 50 },
                    { "House", 0, 0, 100, 100 },
                    { "Kitchen", 30, 0, 80, 30 },
                    { "LivingRoom", 0, 0, 30, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvironmentVariable");

            migrationBuilder.DropTable(
                name: "PartOfHouse");
        }
    }
}
