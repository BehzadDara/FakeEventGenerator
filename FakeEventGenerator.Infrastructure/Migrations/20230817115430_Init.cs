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
                    table.PrimaryKey("PK_NextAction", x => new { x.Id, x.ActionAggregateId });
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
                    { new Guid("036815aa-a179-4039-b2a4-72c13dcda1be"), 500, "Open Door1 Of Balcony", "Open-BalconyDoor1", 100 },
                    { new Guid("21108caa-542c-4dac-b4cf-1f56af9d422f"), 50, "Sit Under BalconyWindow", "Sit-BalconyWindow", 100 },
                    { new Guid("4591c499-74d5-426b-ad52-bd9052344511"), 100, "Move To LivingRoom Human2 Via Corridor", "Move-LivingRoom-Corridor", 100 },
                    { new Guid("4fa6065c-1c81-454d-baab-a1417bfca94e"), 200, "Decrease Degree Of AirConditioner3", "Decrease-Degree", 100 },
                    { new Guid("535537de-922c-46ca-a8b7-7f32225253c6"), 600, "Turn On AirConditioner3", "On-AirConditioner3", 100 },
                    { new Guid("5d7667fc-95a6-459a-9a87-5b91d0351f16"), 1500, "Open Door Of Bedroom2", "Open-Bedroom2Door", 100 },
                    { new Guid("68b9a437-3062-4102-9bb7-11b868b2bcde"), 500, "Move To Corridor Human2 Via Bedroom2", "Move-Corridor-Bedroom1", 100 },
                    { new Guid("69c6f8c5-de4b-4bd2-b682-b60ab996cc7c"), 500, "Move To Balcony Human1 Via Bedroom1", "Move-Balcony-Bedroom1", 100 },
                    { new Guid("8a27ee4c-bdce-4b56-9e35-375b70597271"), 350, "Increase Sound Of TV", "Increase-Sound", 100 },
                    { new Guid("a119641f-72b9-4e0c-8a57-543ffdb161db"), 200, "Turn On TV", "On-TV", 100 },
                    { new Guid("b44848cd-8621-4899-b100-ada573c3d269"), 400, "Open Window Of Balcony", "Open-LivinRoomDoor", 100 },
                    { new Guid("d952318f-bbcf-45f5-8682-00a550804568"), 350, "Decrease Sound Of TV", "Decrease-Sound", 100 },
                    { new Guid("e9b5be47-94e9-4a0e-a50b-85e0ce45890e"), 100, "Open Window Of Balcony", "Open-BalconyWindow", 100 },
                    { new Guid("fa1998cf-ebb5-40ac-bfb3-4e0c8b13673f"), 200, "Human2 Stand In LivingRoom", "Stand-LivingRoom", 100 },
                    { new Guid("fbca3458-5fbd-4efc-9132-36a899d00eda"), 800, "Sit On Sofa1", "Sit-Sofa1", 100 }
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
                    { new Guid("001203e2-9508-4c1d-b797-a746eb45e874"), "Stand", 75, 65, "Medium", "Bored", "Human2" },
                    { new Guid("36450e4c-75eb-4ea2-a843-a90010fff179"), "Stand", 10, 74, "Medium", "Tired", "Human1" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CoordinateX", "CoordinateY", "Description", "IsMovable", "MetaData", "Name", "State", "Type" },
                values: new object[,]
                {
                    { new Guid("04f26c34-5a1f-4f07-bab2-81fb88289450"), 50, 40, "Corridor Lamp", false, "", "Lamp7", "Off", "Electronic" },
                    { new Guid("09473cf1-c034-48b2-a4dd-047ac3db8988"), 15, 30, "Kitchen Door", false, "", "KitchenDoor", "Close", "Openable" },
                    { new Guid("15dd878c-da00-49c2-b056-bf793b384954"), 90, 15, "Bathroom Lamp", false, "", "Lamp5", "Off", "Electronic" },
                    { new Guid("272cc02d-ec3c-400b-99b2-873afea2ea32"), 25, 1, "Kitchen DishWasher", false, "", "DishWasher", "NotBeUsing", "Usable" },
                    { new Guid("2738e12b-5315-4433-b6ad-bcb90e615499"), 75, 80, "Balcony Door2", false, "", "BalconyDoor2", "Close", "Openable" },
                    { new Guid("32df68d2-e0ce-4e3c-aa51-b4451f5cc93a"), 10, 79, "Bedroom1 Computer", false, "", "Computer", "Off", "Electronic" },
                    { new Guid("3cdc3e89-ee65-49ee-a76d-1b47652a55fc"), 35, 15, "LivingRoom Chair1", false, "", "Chair1", "NotBeUsing", "Usable" },
                    { new Guid("42bd8dcc-b46a-4460-bea6-a287e6903b0b"), 51, 55, "Bedroom2 AirConditioner", false, "{\"Temperature\":20,\"Speed\":10}", "AirConditioner2", "Off", "Electronic" },
                    { new Guid("4529e8e1-fe49-4ba6-a3f2-d851faa37860"), 55, 15, "LivingRoom Lamp", false, "", "Lamp4", "Off", "Electronic" },
                    { new Guid("470979e6-7985-4edc-a7a0-27edf36bfeff"), 60, 15, "LivingRoom Sofa3", false, "{\"Capacity\":3}", "Sofa3", "NotFull", "UseWithCapacity" },
                    { new Guid("4932ebcc-e186-4341-a8b7-ad62d8be0d0e"), 70, 20, "LivingRoom Sofa1", false, "{\"Capacity\":1}", "Sofa1", "NotFull", "UseWithCapacity" },
                    { new Guid("5ce97b28-63bc-49e1-b42f-007f33e6ebda"), 55, 30, "LivingRoom Door", false, "", "LivingRoomDoor", "Close", "Openable" },
                    { new Guid("63e11197-b517-42f0-b874-3b76bae68f21"), 75, 50, "Bedroom2 Door", false, "", "Bedroom2Door", "Close", "Openable" },
                    { new Guid("66bd4e1d-af17-4bbb-94c2-188bac67ea36"), 49, 55, "Bedroom1 AirConditioner", false, "", "AirConditioner1", "Off", "Electronic" },
                    { new Guid("6a6642e5-ca97-49d6-a45f-0008c1766613"), 40, 65, "Bedroom1 Bed", false, "", "Bedroom1Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("6d42b09f-db38-4224-9c7e-4f394b173174"), 90, 30, "Bathroom Door", false, "", "BathroomDoor", "Close", "Openable" },
                    { new Guid("719d4b42-5f23-450e-b59f-0eefee12e46f"), 29, 15, "Kitchen WashingMachine", false, "", "WashingMachine", "NotBeUsing", "Usable" },
                    { new Guid("7b170b4d-ec88-42b2-b3d5-81537626403b"), 1, 15, "Kitchen Refrigerator", false, "", "Refrigerator", "Close", "Openable" },
                    { new Guid("81bd2d0b-59c0-40c0-9872-a0613e00ece4"), 90, 79, "Bedroom2 Laptop", true, "{\"Charge\":90,\"IsInCharge\":false}", "Laptop", "Off", "Electronic" },
                    { new Guid("85357074-d5ed-4ca0-a4c7-499f9ca3f276"), 60, 65, "Bedroom2 Bed", false, "{\"Temperature\":20,\"Speed\":10}", "Bedroom2Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("8c325e0c-ed21-4398-b78a-70ebd9738394"), 40, 20, "LivingRoom Chair4", false, "", "Chair4", "NotBeUsing", "Usable" },
                    { new Guid("92018d54-7aa2-4a14-9bc7-fa62ddb2e886"), 25, 65, "Bedroom1 Lamp", false, "{\"Severity\":20}", "Lamp1", "Off", "Electronic" },
                    { new Guid("9213b068-e328-4a6c-8379-61a061e232c4"), 25, 50, "Bedroom1 Door", false, "", "Bedroom1Door", "Close", "Openable" },
                    { new Guid("943d0793-5ead-4f0e-a6db-991a7642b6f0"), 40, 10, "LivingRoom Chair3", false, "", "Chair3", "NotBeUsing", "Usable" },
                    { new Guid("94bdaddb-5c69-45b3-a665-675c2d5b419c"), 15, 15, "Kitchen Lamp", false, "", "Lamp3", "Off", "Electronic" },
                    { new Guid("9500f608-eba5-49b6-b449-41af6199f4d9"), 40, 29, "LivingRoom AirConditioner", false, "{\"Temperature\":20,\"Speed\":10}", "AirConditioner3", "Off", "Electronic" },
                    { new Guid("9c048d63-42fa-4f62-8367-ded8a8fe4d45"), 0, 65, "Bedroom1 Window", false, "", "Bedroom1Window", "Close", "Openable" },
                    { new Guid("9d085476-c8af-44e1-a152-c6fd230856f6"), 15, 1, "Kitchen Oven", false, "", "Oven", "NotBeUsing", "Usable" },
                    { new Guid("a2c50e60-0ca8-49ff-b833-ef00ce0f5311"), 50, 90, "Balcony Lamp", false, "", "Lamp6", "Off", "Electronic" },
                    { new Guid("b9fe06c9-6ba8-408d-9d39-86f64667b13d"), 100, 65, "Bedroom2 Window", false, "", "Bedroom2Window", "Close", "Openable" },
                    { new Guid("ba6d2e1b-1967-44a0-af35-bfc85164534e"), 40, 15, "LivingRoom Table", false, "", "Table", "NotBeUsing", "Usable" },
                    { new Guid("c34371e5-33f5-4978-85c7-3faadd54da9a"), 79, 15, "LivingRoom TV", false, "{\"Channel\":1,\"Sound\":60}", "TV", "Off", "Electronic" },
                    { new Guid("c8ca1f1a-1e31-414d-96de-3e4b1c91bdb3"), 45, 15, "LivingRoom Chair2", false, "", "Chair2", "NotBeUsing", "Usable" },
                    { new Guid("def515b1-59c9-4971-8aa2-b0a68bc3c8c3"), 90, 75, "Bedroom2 Chair", false, "", "Chair21", "NotBeUsing", "Usable" },
                    { new Guid("e1443d18-c717-4349-80cf-dbdc419940a9"), 55, 0, "House Door", false, "", "HouseDoor", "Close", "Openable" },
                    { new Guid("e2de4be0-cc7a-49db-a354-7720ad736613"), 10, 75, "Bedroom1 Chair", false, "", "Chair11", "NotBeUsing", "Usable" },
                    { new Guid("e4584cf0-a363-488c-b141-cd2409e26573"), 50, 100, "Balcony Window", false, "", "BalconyWindow", "Close", "Openable" },
                    { new Guid("ee716306-5f22-49ce-9d75-314071265472"), 25, 80, "Balcony Door1", false, "", "BalconyDoor1", "Close", "Openable" },
                    { new Guid("ef1d4bbb-c278-4ada-a1de-42e4f13c455e"), 70, 10, "LivingRoom Sofa2", false, "{\"Capacity\":2}", "Sofa2", "NotFull", "UseWithCapacity" },
                    { new Guid("fb5b7c72-7408-4b07-ad91-eb115cf1f602"), 75, 65, "Bedroom2 Lamp", false, "{\"Severity\":20}", "Lamp2", "Off", "Electronic" }
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
                    { "Kitchen", 0, 0, 30, 30 },
                    { "LivingRoom", 30, 0, 80, 30 }
                });

            migrationBuilder.InsertData(
                table: "ActionCondition",
                columns: new[] { "Id", "ActionAggregateId", "CaseStudy", "ConditionCaseExpectation", "ConditionCaseType", "ConditionType" },
                values: new object[,]
                {
                    { new Guid("05db8ee0-e98c-4442-afb4-0026cee2f9d9"), new Guid("fa1998cf-ebb5-40ac-bfb3-4e0c8b13673f"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("0953a8c6-b619-4316-8d20-8ca6f50e2680"), new Guid("535537de-922c-46ca-a8b7-7f32225253c6"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("0c05eb49-25fa-4f19-9f17-2345067337f9"), new Guid("d952318f-bbcf-45f5-8682-00a550804568"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("0e56ed70-eba5-41b2-80d4-a251671a34fa"), new Guid("8a27ee4c-bdce-4b56-9e35-375b70597271"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("0ecb932d-d5a2-42f7-9e36-6510e6df4fa3"), new Guid("a119641f-72b9-4e0c-8a57-543ffdb161db"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("1440e890-7fe7-42fe-beff-d845a68b9117"), new Guid("036815aa-a179-4039-b2a4-72c13dcda1be"), "Human1", "Bedroom1", "IsIn", "HumanPosition" },
                    { new Guid("17ab0825-c824-4487-8fef-11c951dd4eed"), new Guid("4591c499-74d5-426b-ad52-bd9052344511"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("17d39fe6-6940-4e3e-a6f8-b40bb9ed1c37"), new Guid("4fa6065c-1c81-454d-baab-a1417bfca94e"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("1cbf85a6-f853-4886-9460-09a0d7bafdaa"), new Guid("21108caa-542c-4dac-b4cf-1f56af9d422f"), "Human1", "Balcony", "IsIn", "HumanPosition" },
                    { new Guid("1ea4f462-d31a-48a2-a3f3-811af48ebd6c"), new Guid("b44848cd-8621-4899-b100-ada573c3d269"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("3db5eac1-f373-4076-892e-a60fff3b1d33"), new Guid("69c6f8c5-de4b-4bd2-b682-b60ab996cc7c"), "Human1", "Bedroom1", "IsIn", "HumanPosition" },
                    { new Guid("40654310-8f3d-4667-9884-686f2e40b2fe"), new Guid("b44848cd-8621-4899-b100-ada573c3d269"), "LivingRoomDoor", "Close", "StateIs", "ItemState" },
                    { new Guid("4958a793-fc1a-4a1f-8e38-c173fe7d4745"), new Guid("8a27ee4c-bdce-4b56-9e35-375b70597271"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("4ddb0264-a946-477e-a84e-127d6e96c131"), new Guid("68b9a437-3062-4102-9bb7-11b868b2bcde"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("53bf4d06-af87-4b8e-b7a2-969c381916e2"), new Guid("d952318f-bbcf-45f5-8682-00a550804568"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("5797f54e-1985-4674-afd5-84e29e6fda93"), new Guid("fbca3458-5fbd-4efc-9132-36a899d00eda"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("5c3fdcef-8260-4f67-9a89-3b4961dda817"), new Guid("4591c499-74d5-426b-ad52-bd9052344511"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("5e7ff93b-20fc-4424-b4ec-e29de6b7333e"), new Guid("8a27ee4c-bdce-4b56-9e35-375b70597271"), "TV", "On", "StateIs", "ItemState" },
                    { new Guid("5ec2ca1d-2ef9-4a21-a76d-9c7e19af1404"), new Guid("b44848cd-8621-4899-b100-ada573c3d269"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("67c2b180-6957-41c7-a126-68199208c698"), new Guid("d952318f-bbcf-45f5-8682-00a550804568"), "TV", "On", "StateIs", "ItemState" },
                    { new Guid("77a28069-f538-4e3e-9c3c-495f8f4974c1"), new Guid("535537de-922c-46ca-a8b7-7f32225253c6"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("79f1b299-739f-4027-b35a-9745d8cf0ea0"), new Guid("5d7667fc-95a6-459a-9a87-5b91d0351f16"), "Human2", "Bedroom2", "IsIn", "HumanPosition" },
                    { new Guid("7ac1065c-cddc-4581-9359-10b12e007007"), new Guid("5d7667fc-95a6-459a-9a87-5b91d0351f16"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("7f8646a5-de3e-417e-9195-ebc11d274f14"), new Guid("21108caa-542c-4dac-b4cf-1f56af9d422f"), "Human1", "Sit", "StateIsNot", "HumanBodyStatus" },
                    { new Guid("8f19437b-4af9-4083-8f38-76e7484dc2e2"), new Guid("4fa6065c-1c81-454d-baab-a1417bfca94e"), "AirConditioner3", "On", "StateIs", "ItemState" },
                    { new Guid("979d8822-23a2-4040-b961-60ea24a724f0"), new Guid("a119641f-72b9-4e0c-8a57-543ffdb161db"), "TV", "Off", "StateIs", "ItemState" },
                    { new Guid("ac212868-830f-47ab-9489-4ef739d3248d"), new Guid("4fa6065c-1c81-454d-baab-a1417bfca94e"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("b0122923-6e02-4ada-9835-7fb26647b445"), new Guid("5d7667fc-95a6-459a-9a87-5b91d0351f16"), "Bedroom1Door", "Close", "StateIs", "ItemState" },
                    { new Guid("b551a8cd-d8d4-42ee-a667-0e278c95825b"), new Guid("21108caa-542c-4dac-b4cf-1f56af9d422f"), "Human1", "Tired", "StateIs", "MentalStatus" },
                    { new Guid("b8c88202-0bb6-404f-9482-db6bf556dba8"), new Guid("69c6f8c5-de4b-4bd2-b682-b60ab996cc7c"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("bc1163fe-e4fa-43a4-bb05-7dfafb68dd29"), new Guid("68b9a437-3062-4102-9bb7-11b868b2bcde"), "Bedroom2Door", "Open", "StateIs", "ItemState" },
                    { new Guid("bc512630-c87a-491f-a0b5-8a67dabcd90c"), new Guid("68b9a437-3062-4102-9bb7-11b868b2bcde"), "Human2", "Bedroom2", "IsIn", "HumanPosition" },
                    { new Guid("d1f4e830-4c78-4016-9084-eab6e2aec4c5"), new Guid("21108caa-542c-4dac-b4cf-1f56af9d422f"), "BalconyWindow", "Open", "StateIs", "ItemState" },
                    { new Guid("d3d6bfa4-aa1f-486d-a2f3-0521328ef56e"), new Guid("a119641f-72b9-4e0c-8a57-543ffdb161db"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("d5994f8d-63dd-4d2e-b842-f05e1bb7bccf"), new Guid("036815aa-a179-4039-b2a4-72c13dcda1be"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("e9e406f8-4553-47bc-8e29-f708f3ffcefa"), new Guid("4591c499-74d5-426b-ad52-bd9052344511"), "LivingRoomDoor", "Open", "StateIs", "ItemState" },
                    { new Guid("eb164d41-2d16-4ed4-9707-9b01d49ca051"), new Guid("e9b5be47-94e9-4a0e-a50b-85e0ce45890e"), "Human1", "Balcony", "IsIn", "HumanPosition" },
                    { new Guid("f085eec9-1d9c-4dd3-9ee3-04ef3e156bc1"), new Guid("69c6f8c5-de4b-4bd2-b682-b60ab996cc7c"), "BalconyDoor1", "Open", "StateIs", "ItemState" },
                    { new Guid("f9670e2d-f906-4282-a1d8-12e9c7b9dc28"), new Guid("fbca3458-5fbd-4efc-9132-36a899d00eda"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("fa0c8736-61b0-4734-9794-92dbea142d75"), new Guid("036815aa-a179-4039-b2a4-72c13dcda1be"), "BalconyDoor1", "Close", "StateIs", "ItemState" },
                    { new Guid("fa5602ea-5e4a-4731-b64e-7e44fdd0251d"), new Guid("e9b5be47-94e9-4a0e-a50b-85e0ce45890e"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("ff08e005-e6a1-4193-ad4f-a296703e2b29"), new Guid("fa1998cf-ebb5-40ac-bfb3-4e0c8b13673f"), "Human2", "Stand", "StateIsNot", "HumanBodyStatus" }
                });

            migrationBuilder.InsertData(
                table: "ActionResult",
                columns: new[] { "Id", "ActionAggregateId", "CaseStudy", "ResultCaseChange", "ResultCaseType", "ResultType" },
                values: new object[,]
                {
                    { new Guid("0a2d855f-ca55-480d-9cd6-a8e461a1e050"), new Guid("21108caa-542c-4dac-b4cf-1f56af9d422f"), "Human1", "Normal", "State", "MentalStatus" },
                    { new Guid("15ce581c-b394-4d67-8ba3-62a9db771bb4"), new Guid("8a27ee4c-bdce-4b56-9e35-375b70597271"), "Light", "10", "Increase", "Environment" },
                    { new Guid("1f9338bd-7c53-42eb-9223-339cef151d56"), new Guid("fbca3458-5fbd-4efc-9132-36a899d00eda"), "Human2", "Sit", "State", "HumanBodyStatus" },
                    { new Guid("23169975-0476-4e07-b186-b22e326dd9cb"), new Guid("b44848cd-8621-4899-b100-ada573c3d269"), "Human2", "55-31", "Position", "HumanPosition" },
                    { new Guid("24806382-d8c2-4322-bfb8-a21e8eca5cc7"), new Guid("68b9a437-3062-4102-9bb7-11b868b2bcde"), "Human2", "75-49", "Position", "HumanPosition" },
                    { new Guid("2f3225bd-e018-48e4-806e-871aaab0fc27"), new Guid("535537de-922c-46ca-a8b7-7f32225253c6"), "AirConditioner3", "On", "State", "ItemState" },
                    { new Guid("2fbceaba-bfb4-4bd3-98ef-5ea9cfc4b607"), new Guid("e9b5be47-94e9-4a0e-a50b-85e0ce45890e"), "Human1", "50-99", "Position", "HumanPosition" },
                    { new Guid("30c7ebfa-3c36-4d7c-a695-97d4e76e0608"), new Guid("fbca3458-5fbd-4efc-9132-36a899d00eda"), "Human2", "70-20", "Position", "HumanPosition" },
                    { new Guid("4479990a-9fb2-4a42-af09-36d2f4d686a0"), new Guid("d952318f-bbcf-45f5-8682-00a550804568"), "Sound", "10-40", "Decrease", "Environment" },
                    { new Guid("483378b3-f3a6-4cb4-a665-09088b3f7713"), new Guid("d952318f-bbcf-45f5-8682-00a550804568"), "TV-Sound", "10-40", "Decrease", "ItemMetaData" },
                    { new Guid("4da22339-a4b0-4a00-a09a-005b536f27e8"), new Guid("e9b5be47-94e9-4a0e-a50b-85e0ce45890e"), "BalconyWindow", "Open", "State", "ItemState" },
                    { new Guid("6b60b803-a85f-463b-b2d4-cc9654e10afc"), new Guid("69c6f8c5-de4b-4bd2-b682-b60ab996cc7c"), "Human1", "25-81", "Position", "HumanPosition" },
                    { new Guid("7a6fb182-d596-4e98-b82a-3b147493a6f9"), new Guid("a119641f-72b9-4e0c-8a57-543ffdb161db"), "TV", "On", "State", "ItemState" },
                    { new Guid("867ef767-db92-4436-a8e6-412f5098fa98"), new Guid("5d7667fc-95a6-459a-9a87-5b91d0351f16"), "Human1", "75-51", "Position", "HumanPosition" },
                    { new Guid("909f66e7-274d-42a5-b145-94c32d2e3113"), new Guid("4591c499-74d5-426b-ad52-bd9052344511"), "Human2", "55-29", "Position", "HumanPosition" },
                    { new Guid("9344652a-2d26-4150-afd2-49cbeca93443"), new Guid("4fa6065c-1c81-454d-baab-a1417bfca94e"), "Degree", "7", "Decrease", "Environment" },
                    { new Guid("9d1c631f-6fbe-4237-8aed-de7c1d4f58e5"), new Guid("b44848cd-8621-4899-b100-ada573c3d269"), "LivingRoomDoor", "Open", "State", "ItemState" },
                    { new Guid("a2ba5d39-beba-46e4-9402-e82d897f0aa4"), new Guid("535537de-922c-46ca-a8b7-7f32225253c6"), "Human2", "40-28", "Position", "HumanPosition" },
                    { new Guid("a7a2244d-9e16-4589-bee9-aac411e4a266"), new Guid("fbca3458-5fbd-4efc-9132-36a899d00eda"), "Sofa1", "Full", "State", "ItemState" },
                    { new Guid("a7d65d82-25c8-4da9-aecc-90cf17752ee4"), new Guid("fa1998cf-ebb5-40ac-bfb3-4e0c8b13673f"), "Human2", "Stand", "State", "HumanBodyStatus" },
                    { new Guid("a99029a0-a3ff-4644-aeca-31ae1cf96428"), new Guid("036815aa-a179-4039-b2a4-72c13dcda1be"), "BalconyDoor1", "Open", "State", "ItemState" },
                    { new Guid("bad013d2-e3a5-4d0a-bf33-5cc640243774"), new Guid("8a27ee4c-bdce-4b56-9e35-375b70597271"), "Sound", "10-40", "Increase", "Environment" },
                    { new Guid("c6fe9a8a-26ac-48a7-94b5-9ceb6f292af8"), new Guid("e9b5be47-94e9-4a0e-a50b-85e0ce45890e"), "Light", "20-IF:Day", "Increase", "Environment" },
                    { new Guid("cfa118b1-1c44-475c-9bea-f5d31a0d6004"), new Guid("4fa6065c-1c81-454d-baab-a1417bfca94e"), "AirConditioner3-Temperature", "5-15", "Decrease", "ItemMetaData" },
                    { new Guid("d579704e-bb80-48b7-9ed3-9daf5e7ea6bc"), new Guid("5d7667fc-95a6-459a-9a87-5b91d0351f16"), "Bedroom2Door", "Open", "State", "ItemState" },
                    { new Guid("e27c180e-9ded-49e6-9b2a-ef08eb50dab9"), new Guid("a119641f-72b9-4e0c-8a57-543ffdb161db"), "Human2", "Normal", "State", "MentalStatus" },
                    { new Guid("e5b5d2cb-7c7b-4c20-b7e8-f203fef4fbd1"), new Guid("8a27ee4c-bdce-4b56-9e35-375b70597271"), "TV-Sound", "10-40", "Increase", "ItemMetaData" },
                    { new Guid("f1931ac5-fdd8-42ba-ae41-872c40f60319"), new Guid("036815aa-a179-4039-b2a4-72c13dcda1be"), "Human1", "25-79", "Position", "HumanPosition" },
                    { new Guid("faca3b9c-2a6f-47a9-b6b9-0f6ac32697f0"), new Guid("d952318f-bbcf-45f5-8682-00a550804568"), "Light", "10", "Increase", "Environment" },
                    { new Guid("fb8bb6e1-f627-4e9b-be83-da3c86ba7339"), new Guid("4fa6065c-1c81-454d-baab-a1417bfca94e"), "Human2", "Cold", "State", "HumanFeelToDegree" },
                    { new Guid("fbc39e98-19ac-42c6-9c72-944dc4555c29"), new Guid("21108caa-542c-4dac-b4cf-1f56af9d422f"), "Human1", "Sit", "State", "HumanBodyStatus" }
                });

            migrationBuilder.InsertData(
                table: "NextAction",
                columns: new[] { "ActionAggregateId", "Id", "Delay", "Possibility" },
                values: new object[,]
                {
                    { new Guid("e9b5be47-94e9-4a0e-a50b-85e0ce45890e"), new Guid("21108caa-542c-4dac-b4cf-1f56af9d422f"), 100, 100 },
                    { new Guid("b44848cd-8621-4899-b100-ada573c3d269"), new Guid("4591c499-74d5-426b-ad52-bd9052344511"), 200, 100 },
                    { new Guid("535537de-922c-46ca-a8b7-7f32225253c6"), new Guid("4fa6065c-1c81-454d-baab-a1417bfca94e"), 200, 100 },
                    { new Guid("4591c499-74d5-426b-ad52-bd9052344511"), new Guid("535537de-922c-46ca-a8b7-7f32225253c6"), 350, 100 },
                    { new Guid("fa1998cf-ebb5-40ac-bfb3-4e0c8b13673f"), new Guid("535537de-922c-46ca-a8b7-7f32225253c6"), 200, 100 },
                    { new Guid("5d7667fc-95a6-459a-9a87-5b91d0351f16"), new Guid("68b9a437-3062-4102-9bb7-11b868b2bcde"), 200, 100 },
                    { new Guid("036815aa-a179-4039-b2a4-72c13dcda1be"), new Guid("69c6f8c5-de4b-4bd2-b682-b60ab996cc7c"), 200, 100 },
                    { new Guid("a119641f-72b9-4e0c-8a57-543ffdb161db"), new Guid("8a27ee4c-bdce-4b56-9e35-375b70597271"), 200, 100 },
                    { new Guid("fbca3458-5fbd-4efc-9132-36a899d00eda"), new Guid("a119641f-72b9-4e0c-8a57-543ffdb161db"), 200, 100 },
                    { new Guid("68b9a437-3062-4102-9bb7-11b868b2bcde"), new Guid("b44848cd-8621-4899-b100-ada573c3d269"), 200, 100 },
                    { new Guid("a119641f-72b9-4e0c-8a57-543ffdb161db"), new Guid("d952318f-bbcf-45f5-8682-00a550804568"), 200, 100 },
                    { new Guid("69c6f8c5-de4b-4bd2-b682-b60ab996cc7c"), new Guid("e9b5be47-94e9-4a0e-a50b-85e0ce45890e"), 200, 100 },
                    { new Guid("4591c499-74d5-426b-ad52-bd9052344511"), new Guid("fbca3458-5fbd-4efc-9132-36a899d00eda"), 200, 100 }
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
