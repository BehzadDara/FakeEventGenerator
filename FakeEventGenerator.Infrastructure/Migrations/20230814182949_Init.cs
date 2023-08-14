using System;
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
                name: "Human",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoordinateX = table.Column<int>(type: "int", nullable: false),
                    CoordinateY = table.Column<int>(type: "int", nullable: false),
                    FeelToDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MentalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Human", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoordinateX = table.Column<int>(type: "int", nullable: false),
                    CoordinateY = table.Column<int>(type: "int", nullable: false),
                    IsMovable = table.Column<bool>(type: "bit", nullable: false),
                    MetaData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
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
                table: "Human",
                columns: new[] { "Id", "BodyStatus", "CoordinateX", "CoordinateY", "FeelToDegree", "MentalStatus", "Name" },
                values: new object[,]
                {
                    { new Guid("3c2d0a3c-868a-4233-9e0c-d4737c4018cc"), "Stand", 10, 74, "Medium", "Busy", "Human1" },
                    { new Guid("c6ba5308-eb22-431e-8886-cd2b37ad7fc7"), "Stand", 75, 65, "Medium", "Normal", "Human2" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CoordinateX", "CoordinateY", "Description", "IsMovable", "MetaData", "Name", "State", "Type" },
                values: new object[,]
                {
                    { new Guid("10b753a6-57ea-4372-83ef-d906b01c74a6"), 75, 65, "Bedroom2 Lamp", false, "{\"Severity\":20}", "Lamp2", "Off", "Electronic" },
                    { new Guid("136c2951-870c-44e4-9cea-621665bcafe7"), 40, 65, "Bedroom1 Bed", false, "", "Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("16189e20-a390-441d-9577-bb306619d303"), 0, 65, "Bedroom1 Window", false, "", "Window", "Close", "Openable" },
                    { new Guid("18c35fe8-3e6f-49e3-8b19-1e8bd4b104dd"), 90, 75, "Bedroom2 Chair", false, "", "Chair21", "NotBeUsing", "Usable" },
                    { new Guid("1cb48a6a-60b2-4ac5-ba48-467d1fc4aa38"), 10, 79, "Bedroom1 Computer", false, "", "Computer", "Off", "Electronic" },
                    { new Guid("2164b445-7313-4028-bec3-ec5eef661df2"), 40, 15, "LivingRoom Table", false, "", "Table", "NotBeUsing", "Usable" },
                    { new Guid("2ea68b9a-608f-4905-bc9e-c12d4ca59be1"), 90, 15, "Bathroom Lamp", false, "", "Lamp5", "Off", "Electronic" },
                    { new Guid("30a68b44-99ed-44df-90e5-71378466423c"), 10, 75, "Bedroom1 Chair", false, "", "Chair11", "NotBeUsing", "Usable" },
                    { new Guid("361fb835-b978-4e15-8bf4-c6e3f04abf51"), 15, 30, "Kitchen Door", false, "", "Door", "Close", "Openable" },
                    { new Guid("37505a1f-06ba-4afa-9b66-766f9910dddc"), 50, 100, "Balcony Window", false, "", "Window", "Close", "Openable" },
                    { new Guid("3a6b7b33-ba8e-430b-8f54-c0160deccb2d"), 25, 1, "Kitchen DishWasher", false, "", "DishWasher", "NotBeUsing", "Usable" },
                    { new Guid("43a35dff-ba06-43e8-bd58-4816fb50ba1d"), 55, 30, "LivingRoom Door", false, "", "Door", "Close", "Openable" },
                    { new Guid("46733dcc-b144-443c-8cf6-7bf6b0c60cf4"), 51, 55, "Bedroom2 AirConditioner", false, "{\"Tempreture\":20,\"Speed\":10}", "AirConditioner2", "Off", "Electronic" },
                    { new Guid("50e06a28-098a-40f0-9483-9841fe41f925"), 55, 0, "House Door", false, "", "Door", "Close", "Openable" },
                    { new Guid("524eb5c5-689f-4b4f-9423-4931f0587e74"), 90, 30, "Bathroom Door", false, "", "Door", "Close", "Openable" },
                    { new Guid("597ee846-e091-4eb8-9808-bad5f5a41d38"), 75, 80, "Balcony Door1", false, "", "Door", "Close", "Openable" },
                    { new Guid("60103d9a-7924-4cf3-9d92-d288aab5f5c0"), 50, 90, "Balcony Lamp", false, "", "Lamp6", "Off", "Electronic" },
                    { new Guid("8042f5b4-b929-4641-877f-eebf201e43bc"), 15, 15, "Kitchen Lamp", false, "", "Lamp3", "Off", "Electronic" },
                    { new Guid("813fb3b9-0d03-4f42-9854-690516eb8abc"), 40, 20, "LivingRoom Chair4", false, "", "Chair4", "NotBeUsing", "Usable" },
                    { new Guid("8348e3ee-c646-43f6-a98e-56ed2ad7167e"), 40, 10, "LivingRoom Chair3", false, "", "Chair3", "NotBeUsing", "Usable" },
                    { new Guid("91cf5265-9fc4-4f2c-8040-16bd4a66836c"), 50, 40, "Corridor Lamp", false, "", "Lamp7", "Off", "Electronic" },
                    { new Guid("91e8e7a2-8caf-48b3-80f3-4198a4dc10b8"), 79, 15, "LivingRoom TV", false, "{\"Channel\":1,\"Sound\":20}", "TV", "Off", "Electronic" },
                    { new Guid("94d61dc0-2e8d-40eb-8bcd-2569f75dc301"), 49, 55, "Bedroom1 AirConditioner", false, "", "AirConditioner1", "Off", "Electronic" },
                    { new Guid("9802903f-666d-47a8-9077-8921ba275bcc"), 40, 29, "LivingRoom AirConditioner", false, "{\"Tempreture\":20,\"Speed\":10}", "AirConditioner3", "Off", "Electronic" },
                    { new Guid("a4648e7c-5285-475b-820f-238d1ad41d08"), 25, 65, "Bedroom1 Lamp", false, "{\"Severity\":20}", "Lamp1", "Off", "Electronic" },
                    { new Guid("a90a860a-9683-46c9-8ab3-cd94b64c3355"), 45, 15, "LivingRoom Chair2", false, "", "Chair2", "NotBeUsing", "Usable" },
                    { new Guid("ba7d9853-e268-4ec2-b0ce-c4289b3f5b3e"), 15, 1, "Kitchen Oven", false, "", "Oven", "NotBeUsing", "Usable" },
                    { new Guid("ba89e02a-c081-4d15-ab7a-8aa04261f7ce"), 60, 15, "LivingRoom Sofa3", false, "", "Sofa3", "NotFull", "UseWithCapacity" },
                    { new Guid("bc811814-6dcf-4f3d-a334-ab744bff475e"), 70, 10, "LivingRoom Sofa2", false, "", "Sofa2", "NotFull", "UseWithCapacity" },
                    { new Guid("c0f1e100-8ea0-48ec-876c-de9b0f734599"), 35, 15, "LivingRoom Chair1", false, "", "Chair1", "NotBeUsing", "Usable" },
                    { new Guid("c76a6f26-f861-4b42-9c62-4462024fbfdc"), 60, 65, "Bedroom2 Bed", false, "{\"Tempreture\":20,\"Speed\":10}", "Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("c98c422a-0361-4c9e-8586-ded65f83f01c"), 25, 80, "Balcony Door1", false, "", "Door", "Close", "Openable" },
                    { new Guid("d19ce36b-e4ec-4b89-9020-1c1dd1f284b6"), 29, 15, "Kitchen WashingMachine", false, "", "WashingMachine", "NotBeUsing", "Usable" },
                    { new Guid("d67e7534-1ffe-43ab-80a7-671fb5e744b1"), 70, 20, "LivingRoom Sofa1", false, "", "Sofa1", "NotFull", "UseWithCapacity" },
                    { new Guid("dad4e662-0055-4f64-b138-c623b543d986"), 55, 15, "LivingRoom Lamp", false, "", "Lamp4", "Off", "Electronic" },
                    { new Guid("e2239a69-88cf-46d0-b41d-aa8350e08882"), 75, 50, "Bedroom2 Door", false, "", "Door", "Close", "Openable" },
                    { new Guid("e30e350c-a035-42f0-8bfa-31924043a0b3"), 25, 50, "Bedroom1 Door", false, "", "Door", "Close", "Openable" },
                    { new Guid("f47ed837-3454-433c-8f0f-e3108d2700ec"), 1, 15, "Kitchen Refrigerator", false, "", "Refrigerator", "Close", "Openable" },
                    { new Guid("f8455bc0-b929-4c0a-86ac-fe7e8eab92a3"), 90, 79, "Bedroom2 Laptop", true, "{\"Charge\":90}", "Laptop", "Off", "Electronic" },
                    { new Guid("fd55dba4-b7a9-4d5f-b049-67235ee3fb7d"), 100, 65, "Bedroom2 Window", false, "", "Window", "Close", "Openable" }
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
                name: "Human");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "PartOfHouse");
        }
    }
}
