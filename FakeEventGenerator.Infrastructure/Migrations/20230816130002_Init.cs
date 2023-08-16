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
                name: "ActionAggregate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Delay = table.Column<int>(type: "int", nullable: false),
                    StartPossibility = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionAggregate", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "ActionCondition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionAggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionCaseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionCaseExpectation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionCondition_ActionAggregate_ActionAggregateId",
                        column: x => x.ActionAggregateId,
                        principalTable: "ActionAggregate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionAggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResultType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultCaseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultCaseChange = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionResult_ActionAggregate_ActionAggregateId",
                        column: x => x.ActionAggregateId,
                        principalTable: "ActionAggregate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NextAction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionAggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Possibility = table.Column<int>(type: "int", nullable: false),
                    Delay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NextAction_ActionAggregate_ActionAggregateId",
                        column: x => x.ActionAggregateId,
                        principalTable: "ActionAggregate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActionAggregate",
                columns: new[] { "Id", "Delay", "Description", "Name", "StartPossibility" },
                values: new object[,]
                {
                    { new Guid("3d90a288-5cf7-4589-b234-f4f32a94a76c"), 500, "Open Door1 Of Balcony", "Open-BalconyDoor1", 100 },
                    { new Guid("3f50c444-1339-4851-ae67-92797ded432f"), 500, "Move To Balcony Human1 Via Bedroom1", "Move-Balcony-Bedroom1", 100 },
                    { new Guid("53a6c5ba-628d-4e0b-aaa6-9f9347898323"), 100, "Open Window Of Balcony", "Open-BalconyWindow", 100 }
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
                    { new Guid("321beed9-358e-4b60-be28-20d7b9066793"), "Stand", 75, 65, "Medium", "Normal", "Human2" },
                    { new Guid("fb065ded-e981-48a2-a082-30a5a2fb5887"), "Stand", 10, 74, "Medium", "Busy", "Human1" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CoordinateX", "CoordinateY", "Description", "IsMovable", "MetaData", "Name", "State", "Type" },
                values: new object[,]
                {
                    { new Guid("00e2bfdb-d963-4f4d-b89f-095cba8d3832"), 90, 75, "Bedroom2 Chair", false, "", "Chair21", "NotBeUsing", "Usable" },
                    { new Guid("05027df8-8cea-49db-9b7c-3c52491ab36e"), 55, 15, "LivingRoom Lamp", false, "", "Lamp4", "Off", "Electronic" },
                    { new Guid("0d0bdd76-396f-405e-885e-df295b5af8e4"), 10, 79, "Bedroom1 Computer", false, "", "Computer", "Off", "Electronic" },
                    { new Guid("11c01991-6b71-4ae4-854c-4dc2ae208b25"), 50, 40, "Corridor Lamp", false, "", "Lamp7", "Off", "Electronic" },
                    { new Guid("19219064-e9b2-4676-bd2b-e1770bff4819"), 90, 79, "Bedroom2 Laptop", true, "{\"Charge\":90,\"IsInCharge\":false}", "Laptop", "Off", "Electronic" },
                    { new Guid("1a296ac8-9110-4fda-b71f-37721efa10eb"), 40, 15, "LivingRoom Table", false, "", "Table", "NotBeUsing", "Usable" },
                    { new Guid("1a3259b2-5737-4b82-97be-786611b8a0df"), 25, 65, "Bedroom1 Lamp", false, "{\"Severity\":20}", "Lamp1", "Off", "Electronic" },
                    { new Guid("1a8497fe-3e02-492d-a79c-738082d3e6d1"), 45, 15, "LivingRoom Chair2", false, "", "Chair2", "NotBeUsing", "Usable" },
                    { new Guid("1cf99f3d-6a30-4c7b-b05d-b9622e531744"), 40, 65, "Bedroom1 Bed", false, "", "Bedroom1Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("22d97ae6-74d3-45a5-981e-502ea79b7280"), 79, 15, "LivingRoom TV", false, "{\"Channel\":1,\"Sound\":20}", "TV", "Off", "Electronic" },
                    { new Guid("2841db9a-6e23-4ae3-9833-28fb2e39a796"), 55, 0, "House Door", false, "", "HouseDoor", "Close", "Openable" },
                    { new Guid("2bbf378b-f8b4-4657-88a5-c43f0b7a94c2"), 75, 50, "Bedroom2 Door", false, "", "Bedroom2Door", "Close", "Openable" },
                    { new Guid("3833082c-00d9-4efe-86ca-6a43d51fb8f2"), 25, 80, "Balcony Door1", false, "", "BalconyDoor1", "Close", "Openable" },
                    { new Guid("3a2c99e5-d563-4bd2-8a38-3e07918dba48"), 100, 65, "Bedroom2 Window", false, "", "Bedroom2Window", "Close", "Openable" },
                    { new Guid("40dc254f-6384-4fe1-9570-ee7b381fdbe9"), 35, 15, "LivingRoom Chair1", false, "", "Chair1", "NotBeUsing", "Usable" },
                    { new Guid("5592f0b2-9085-4774-b57b-8423e6dfc381"), 40, 10, "LivingRoom Chair3", false, "", "Chair3", "NotBeUsing", "Usable" },
                    { new Guid("5a8fc718-90fd-4a64-92e8-efff24f4069e"), 70, 10, "LivingRoom Sofa2", false, "{\"Capacity\":2}", "Sofa2", "NotFull", "UseWithCapacity" },
                    { new Guid("5d85416f-e96d-4cc9-bb09-52a765f3330f"), 75, 80, "Balcony Door2", false, "", "BalconyDoor2", "Close", "Openable" },
                    { new Guid("5fd39c5f-f6a3-475e-9774-b5e8e875bd66"), 40, 29, "LivingRoom AirConditioner", false, "{\"Tempreture\":20,\"Speed\":10}", "AirConditioner3", "Off", "Electronic" },
                    { new Guid("61f404b7-983f-483e-8e9c-485af9907498"), 70, 20, "LivingRoom Sofa1", false, "{\"Capacity\":1}", "Sofa1", "NotFull", "UseWithCapacity" },
                    { new Guid("6369fcbb-b420-476c-9e43-82c00921345f"), 60, 65, "Bedroom2 Bed", false, "{\"Tempreture\":20,\"Speed\":10}", "Bedroom2Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("6b855050-db16-4ba1-a942-28b64d9353eb"), 90, 15, "Bathroom Lamp", false, "", "Lamp5", "Off", "Electronic" },
                    { new Guid("7c396700-4f8d-40a0-9412-3a6501a0a8c9"), 25, 1, "Kitchen DishWasher", false, "", "DishWasher", "NotBeUsing", "Usable" },
                    { new Guid("7f224616-7357-42f8-a0ae-418ce2a2f8d0"), 15, 30, "Kitchen Door", false, "", "KitchenDoor", "Close", "Openable" },
                    { new Guid("86c3351e-5d7b-49bb-bcf4-f1f4badc2772"), 60, 15, "LivingRoom Sofa3", false, "{\"Capacity\":3}", "Sofa3", "NotFull", "UseWithCapacity" },
                    { new Guid("88eff959-6a62-46e4-8b96-81deed14dfa7"), 1, 15, "Kitchen Refrigerator", false, "", "Refrigerator", "Close", "Openable" },
                    { new Guid("8bc9be23-a1c7-43b7-967b-26a444e3ac28"), 15, 15, "Kitchen Lamp", false, "", "Lamp3", "Off", "Electronic" },
                    { new Guid("b61969ed-e087-43b0-8596-d582868bad22"), 49, 55, "Bedroom1 AirConditioner", false, "", "AirConditioner1", "Off", "Electronic" },
                    { new Guid("c3e5dcab-fc68-4185-93ab-7be7065ce7a5"), 29, 15, "Kitchen WashingMachine", false, "", "WashingMachine", "NotBeUsing", "Usable" },
                    { new Guid("d229d5b0-ddaa-4fbc-a768-fb0ebd51a8f3"), 51, 55, "Bedroom2 AirConditioner", false, "{\"Tempreture\":20,\"Speed\":10}", "AirConditioner2", "Off", "Electronic" },
                    { new Guid("d6320cbf-97af-40d1-ae24-cc8e668f8b74"), 25, 50, "Bedroom1 Door", false, "", "Bedroom1Door", "Close", "Openable" },
                    { new Guid("dda5f157-f911-42df-9426-0621ed8a9ac1"), 10, 75, "Bedroom1 Chair", false, "", "Chair11", "NotBeUsing", "Usable" },
                    { new Guid("de2e5a80-8fdf-4fca-977e-46abddf8ea37"), 40, 20, "LivingRoom Chair4", false, "", "Chair4", "NotBeUsing", "Usable" },
                    { new Guid("e3e6019b-06d7-476a-8864-bb502032f4a3"), 75, 65, "Bedroom2 Lamp", false, "{\"Severity\":20}", "Lamp2", "Off", "Electronic" },
                    { new Guid("e746daa1-2723-4f70-813d-81f57744bb4a"), 50, 90, "Balcony Lamp", false, "", "Lamp6", "Off", "Electronic" },
                    { new Guid("e7cde2cf-1457-4341-9f88-532939a38450"), 15, 1, "Kitchen Oven", false, "", "Oven", "NotBeUsing", "Usable" },
                    { new Guid("f209ee75-a5f5-4636-997b-3fbac806863e"), 55, 30, "LivingRoom Door", false, "", "LivingRoomDoor", "Close", "Openable" },
                    { new Guid("f5475a58-f287-46ed-ac8e-5e73d6951695"), 0, 65, "Bedroom1 Window", false, "", "Bedroom1Window", "Close", "Openable" },
                    { new Guid("f64e15df-f473-4bc6-b4e1-f4f9c08fa5a0"), 90, 30, "Bathroom Door", false, "", "BathroomDoor", "Close", "Openable" },
                    { new Guid("f81b11ed-9b88-475e-9eaf-9160cb6927ce"), 50, 100, "Balcony Window", false, "", "BalconyWindow", "Close", "Openable" }
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

            migrationBuilder.InsertData(
                table: "ActionCondition",
                columns: new[] { "Id", "ActionAggregateId", "CaseStudy", "ConditionCaseExpectation", "ConditionCaseType", "ConditionType" },
                values: new object[,]
                {
                    { new Guid("0efd6ae1-d2b0-404d-80e4-9b63bf740b32"), new Guid("3f50c444-1339-4851-ae67-92797ded432f"), "Human1", "BodyStatus-Stand", "StateIs", "State" },
                    { new Guid("1857b7d1-b69e-4401-9ca0-f2713decbb14"), new Guid("53a6c5ba-628d-4e0b-aaa6-9f9347898323"), "Human", "Balcony", "IsIn", "Position" },
                    { new Guid("463f01fc-1d15-420f-8117-7556697268a2"), new Guid("53a6c5ba-628d-4e0b-aaa6-9f9347898323"), "Human", "BodyStatus Stand", "StateIs", "State" },
                    { new Guid("75d99ed8-166d-4d3b-b3c2-5fb8cc1f5f3f"), new Guid("3d90a288-5cf7-4589-b234-f4f32a94a76c"), "BalconyDoor1", "Close", "StateIs", "State" },
                    { new Guid("76824ac4-df17-4410-a202-64200b0a69ce"), new Guid("3d90a288-5cf7-4589-b234-f4f32a94a76c"), "Human1", "BodyStatus-Stand", "StateIs", "State" },
                    { new Guid("a9e7fdca-7f55-41df-9e56-02c30e0b65f7"), new Guid("3f50c444-1339-4851-ae67-92797ded432f"), "BalconyDoor1", "Open", "StateIs", "State" },
                    { new Guid("b3836a5f-f721-4693-aaa2-1f5b529dcaad"), new Guid("3f50c444-1339-4851-ae67-92797ded432f"), "Human1", "Bedroom1", "IsIn", "Position" },
                    { new Guid("c0eecd5a-4cf4-4d3c-8d59-080ebc3fc2f0"), new Guid("3d90a288-5cf7-4589-b234-f4f32a94a76c"), "Human1", "Bedroom1", "IsIn", "Position" }
                });

            migrationBuilder.InsertData(
                table: "ActionResult",
                columns: new[] { "Id", "ActionAggregateId", "CaseStudy", "ResultCaseChange", "ResultCaseType", "ResultType" },
                values: new object[,]
                {
                    { new Guid("3cb5b84c-ea94-43b3-aa21-c3064df33071"), new Guid("3d90a288-5cf7-4589-b234-f4f32a94a76c"), "Human1", "25-79", "Position", "Position" },
                    { new Guid("7449caec-46eb-4f59-9cdf-5b4709db75d7"), new Guid("53a6c5ba-628d-4e0b-aaa6-9f9347898323"), "BalconyWindow", "Open", "State", "State" },
                    { new Guid("a9e26610-9172-46e1-a29d-e4ff144c70b1"), new Guid("53a6c5ba-628d-4e0b-aaa6-9f9347898323"), "Human", "50-99", "Position", "Position" },
                    { new Guid("d2ac77f8-187c-460f-89e3-3885b3315d35"), new Guid("53a6c5ba-628d-4e0b-aaa6-9f9347898323"), "Light", "20-IF:Day", "Increase", "Environment" },
                    { new Guid("db5e04c1-cbd0-4560-979d-546755abfea6"), new Guid("3f50c444-1339-4851-ae67-92797ded432f"), "Human1", "25-81", "Position", "Position" }
                });

            migrationBuilder.InsertData(
                table: "NextAction",
                columns: new[] { "Id", "ActionAggregateId", "Delay", "Possibility" },
                values: new object[,]
                {
                    { new Guid("a53a02ae-e731-46db-a0e6-de7a7742a5ee"), new Guid("3d90a288-5cf7-4589-b234-f4f32a94a76c"), 200, 100 },
                    { new Guid("e2bbca44-ecc7-436e-89c6-a19fc20d8d8a"), new Guid("3f50c444-1339-4851-ae67-92797ded432f"), 200, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionCondition_ActionAggregateId",
                table: "ActionCondition",
                column: "ActionAggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionResult_ActionAggregateId",
                table: "ActionResult",
                column: "ActionAggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_NextAction_ActionAggregateId",
                table: "NextAction",
                column: "ActionAggregateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionCondition");

            migrationBuilder.DropTable(
                name: "ActionResult");

            migrationBuilder.DropTable(
                name: "EnvironmentVariable");

            migrationBuilder.DropTable(
                name: "Human");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "NextAction");

            migrationBuilder.DropTable(
                name: "PartOfHouse");

            migrationBuilder.DropTable(
                name: "ActionAggregate");
        }
    }
}
