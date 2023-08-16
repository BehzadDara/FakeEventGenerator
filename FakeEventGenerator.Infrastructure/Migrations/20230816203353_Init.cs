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
                    { new Guid("1b0bc061-5262-437e-b662-b8635e0ef807"), 100, "Move To LivingRoom Human2 Via Corridor", "Move-LivingRoom-Corridor", 100 },
                    { new Guid("1b78c171-dc4d-4d23-98ee-7cd29b27f260"), 500, "Open Door1 Of Balcony", "Open-BalconyDoor1", 100 },
                    { new Guid("82aeab09-7832-463b-a7e9-5f1c62939906"), 50, "Sit Under BalconyWindow", "Sit-BalconyWindow", 100 },
                    { new Guid("8834a194-0000-409c-8d78-e096d022efc6"), 500, "Move To Corridor Human2 Via Bedroom2", "Move-Corridor-Bedroom1", 100 },
                    { new Guid("8af11ed5-599d-404f-8fa6-5f7172c1378c"), 800, "Sit On Sofa1", "Sit-Sofa1", 100 },
                    { new Guid("8f0c7f87-effd-41a9-95a5-74e65737a59f"), 350, "Decrease Sound Of TV", "Decrease-Sound", 100 },
                    { new Guid("9e87bc7a-820b-4e19-9e5f-c59b37d9a034"), 350, "Increase Sound Of TV", "Increase-Sound", 100 },
                    { new Guid("bdd1fe34-1872-4124-92c4-098815454a75"), 1500, "Open Door Of Bedroom2", "Open-Bedroom2Door", 100 },
                    { new Guid("bf561eff-18a0-4d19-9687-fbedcdfed65d"), 200, "Turn On TV", "On-TV", 100 },
                    { new Guid("d97e1bc6-49f3-4f20-af2a-5ac18be5c38c"), 500, "Move To Balcony Human1 Via Bedroom1", "Move-Balcony-Bedroom1", 100 },
                    { new Guid("e097576e-2eed-4e4f-9e45-4bbf9e9632a7"), 100, "Open Window Of Balcony", "Open-BalconyWindow", 100 },
                    { new Guid("ea59cf93-ca5b-41e1-bf45-f18524a0b2cb"), 400, "Open Window Of Balcony", "Open-LivinRoomDoor", 100 }
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
                    { new Guid("b6add138-5530-4e30-ae0f-2132450821cf"), "Stand", 10, 74, "Medium", "Tired", "Human1" },
                    { new Guid("fe42a43b-d9b5-4b5b-8e10-0ec8a4a9c6ed"), "Stand", 75, 65, "Medium", "Bored", "Human2" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CoordinateX", "CoordinateY", "Description", "IsMovable", "MetaData", "Name", "State", "Type" },
                values: new object[,]
                {
                    { new Guid("0793f3cc-7dcb-45bd-a4e3-7c74801403be"), 40, 20, "LivingRoom Chair4", false, "", "Chair4", "NotBeUsing", "Usable" },
                    { new Guid("0cf4ff24-8a07-4065-9c72-51ea4b6a1ee0"), 55, 15, "LivingRoom Lamp", false, "", "Lamp4", "Off", "Electronic" },
                    { new Guid("0e3f01eb-fe44-4334-b891-14eb8e4b8810"), 50, 40, "Corridor Lamp", false, "", "Lamp7", "Off", "Electronic" },
                    { new Guid("23a83edc-7770-4dc1-a936-ef51b926661f"), 40, 15, "LivingRoom Table", false, "", "Table", "NotBeUsing", "Usable" },
                    { new Guid("2728f1d9-6b74-4701-93fc-b75c9c8dd341"), 79, 15, "LivingRoom TV", false, "{\"Channel\":1,\"Sound\":60}", "TV", "Off", "Electronic" },
                    { new Guid("36c251b5-2e84-4281-9b83-866494e5270f"), 90, 79, "Bedroom2 Laptop", true, "{\"Charge\":90,\"IsInCharge\":false}", "Laptop", "Off", "Electronic" },
                    { new Guid("39c772c3-cb6a-47aa-95cf-228af270e550"), 75, 50, "Bedroom2 Door", false, "", "Bedroom2Door", "Close", "Openable" },
                    { new Guid("39dee87f-5726-4bdf-b1c8-f67223327200"), 70, 10, "LivingRoom Sofa2", false, "{\"Capacity\":2}", "Sofa2", "NotFull", "UseWithCapacity" },
                    { new Guid("3ec9caf8-a7c3-43ff-a67b-7ea42cac3aea"), 40, 65, "Bedroom1 Bed", false, "", "Bedroom1Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("4413de5e-b8c8-49f1-848e-980015d4c958"), 15, 30, "Kitchen Door", false, "", "KitchenDoor", "Close", "Openable" },
                    { new Guid("48263e99-d9bc-460a-962b-349b760d5c8e"), 50, 90, "Balcony Lamp", false, "", "Lamp6", "Off", "Electronic" },
                    { new Guid("49ffa595-7aae-4a27-bb47-ed757dd682f6"), 75, 80, "Balcony Door2", false, "", "BalconyDoor2", "Close", "Openable" },
                    { new Guid("50023ba0-64fe-4d3a-8e05-268bfc85164b"), 50, 100, "Balcony Window", false, "", "BalconyWindow", "Close", "Openable" },
                    { new Guid("515b2bbf-71c9-4881-a030-002a4fc20177"), 55, 30, "LivingRoom Door", false, "", "LivingRoomDoor", "Close", "Openable" },
                    { new Guid("5285947f-b768-4b62-a34f-f27ae94353af"), 90, 75, "Bedroom2 Chair", false, "", "Chair21", "NotBeUsing", "Usable" },
                    { new Guid("545d8181-af3c-4fd4-9d37-de8554b2ea50"), 60, 15, "LivingRoom Sofa3", false, "{\"Capacity\":3}", "Sofa3", "NotFull", "UseWithCapacity" },
                    { new Guid("55dbf1e8-4347-422f-905f-832fa69508b8"), 55, 0, "House Door", false, "", "HouseDoor", "Close", "Openable" },
                    { new Guid("5b62adaa-2947-47be-a3bb-93260b608d39"), 40, 10, "LivingRoom Chair3", false, "", "Chair3", "NotBeUsing", "Usable" },
                    { new Guid("5d2d8974-9b4a-44ff-a33c-b37a14607a7c"), 25, 65, "Bedroom1 Lamp", false, "{\"Severity\":20}", "Lamp1", "Off", "Electronic" },
                    { new Guid("5e43e590-139a-4d26-81cb-71e5527ff9f2"), 90, 15, "Bathroom Lamp", false, "", "Lamp5", "Off", "Electronic" },
                    { new Guid("721ff46b-d4cd-46d3-ba2f-7da791a8d5ea"), 51, 55, "Bedroom2 AirConditioner", false, "{\"Temperature\":20,\"Speed\":10}", "AirConditioner2", "Off", "Electronic" },
                    { new Guid("73f830bc-403e-4e5d-a6e8-5dc8c6914a0c"), 70, 20, "LivingRoom Sofa1", false, "{\"Capacity\":1}", "Sofa1", "NotFull", "UseWithCapacity" },
                    { new Guid("7a6cfb31-a305-49bf-82d2-92fafa43d746"), 25, 1, "Kitchen DishWasher", false, "", "DishWasher", "NotBeUsing", "Usable" },
                    { new Guid("89d952ce-3ed6-4746-8f49-e68a64b71710"), 1, 15, "Kitchen Refrigerator", false, "", "Refrigerator", "Close", "Openable" },
                    { new Guid("920b1697-0443-4041-9679-be1098d3e85e"), 10, 75, "Bedroom1 Chair", false, "", "Chair11", "NotBeUsing", "Usable" },
                    { new Guid("a337aab3-669e-4d95-b6c3-f4499e01f99f"), 0, 65, "Bedroom1 Window", false, "", "Bedroom1Window", "Close", "Openable" },
                    { new Guid("a3d7bb68-1fde-4b4c-a041-0c9c8cb68350"), 45, 15, "LivingRoom Chair2", false, "", "Chair2", "NotBeUsing", "Usable" },
                    { new Guid("b20bd08f-512d-4df2-bad7-cee04c0c7d05"), 25, 80, "Balcony Door1", false, "", "BalconyDoor1", "Close", "Openable" },
                    { new Guid("b90eb2bb-22fb-4fd6-9686-c8235ab6cc7f"), 15, 15, "Kitchen Lamp", false, "", "Lamp3", "Off", "Electronic" },
                    { new Guid("bcbdcef3-2bc8-40c9-9ce1-e27a30f8a160"), 40, 29, "LivingRoom AirConditioner", false, "{\"Temperature\":20,\"Speed\":10}", "AirConditioner3", "Off", "Electronic" },
                    { new Guid("c5abb1f1-dacf-4753-99a1-4241d3cdd38f"), 25, 50, "Bedroom1 Door", false, "", "Bedroom1Door", "Close", "Openable" },
                    { new Guid("c5ef7792-4434-4238-9094-d4567142e92b"), 75, 65, "Bedroom2 Lamp", false, "{\"Severity\":20}", "Lamp2", "Off", "Electronic" },
                    { new Guid("c5f51ee9-6870-475c-b4bd-03d2e3edf48f"), 15, 1, "Kitchen Oven", false, "", "Oven", "NotBeUsing", "Usable" },
                    { new Guid("ca6dcb1e-8ca5-47f2-829d-97847c9c58a9"), 60, 65, "Bedroom2 Bed", false, "{\"Temperature\":20,\"Speed\":10}", "Bedroom2Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("d57a32e6-73ea-4eeb-a302-e2b965f02ba3"), 49, 55, "Bedroom1 AirConditioner", false, "", "AirConditioner1", "Off", "Electronic" },
                    { new Guid("ed08ce63-7136-49b0-809d-3e9630bb031f"), 10, 79, "Bedroom1 Computer", false, "", "Computer", "Off", "Electronic" },
                    { new Guid("ed780062-c893-4fcb-88bf-d53c29b28fe6"), 29, 15, "Kitchen WashingMachine", false, "", "WashingMachine", "NotBeUsing", "Usable" },
                    { new Guid("f37f3775-432f-4ffa-8c94-4cf888501a95"), 90, 30, "Bathroom Door", false, "", "BathroomDoor", "Close", "Openable" },
                    { new Guid("f7f1b973-1eca-4193-a195-d92941741bef"), 100, 65, "Bedroom2 Window", false, "", "Bedroom2Window", "Close", "Openable" },
                    { new Guid("fee92df1-9f1d-4985-bf1c-5843311f6294"), 35, 15, "LivingRoom Chair1", false, "", "Chair1", "NotBeUsing", "Usable" }
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
                    { new Guid("053aa2d8-2a6e-43b8-b4dd-4444a687c104"), new Guid("8f0c7f87-effd-41a9-95a5-74e65737a59f"), "TV", "On", "StateIs", "ItemState" },
                    { new Guid("06583f26-93a5-4024-9461-fdf7dbb0a14b"), new Guid("d97e1bc6-49f3-4f20-af2a-5ac18be5c38c"), "Human1", "Bedroom1", "IsIn", "HumanPosition" },
                    { new Guid("0c42dc8a-daf0-426d-94ed-1ebe695974d7"), new Guid("bdd1fe34-1872-4124-92c4-098815454a75"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("0e3008f8-3e44-46d1-9d8c-bbe276882f2c"), new Guid("8af11ed5-599d-404f-8fa6-5f7172c1378c"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("1a90fafa-a1f9-4b36-b8f9-dc488ca7504f"), new Guid("1b0bc061-5262-437e-b662-b8635e0ef807"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("21b080ea-be77-4386-8e73-d50686d8a922"), new Guid("ea59cf93-ca5b-41e1-bf45-f18524a0b2cb"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("2417356f-9fb6-44a1-a84b-e500f5611510"), new Guid("e097576e-2eed-4e4f-9e45-4bbf9e9632a7"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("2756069a-94a5-425f-96c1-fead96380703"), new Guid("d97e1bc6-49f3-4f20-af2a-5ac18be5c38c"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("2b5dc153-feb4-48bb-bfd8-a7163fbe7635"), new Guid("9e87bc7a-820b-4e19-9e5f-c59b37d9a034"), "TV", "On", "StateIs", "ItemState" },
                    { new Guid("3a0ee0df-428c-4008-938b-7255cc7dd459"), new Guid("82aeab09-7832-463b-a7e9-5f1c62939906"), "Human1", "Balcony", "IsIn", "HumanPosition" },
                    { new Guid("570173f2-0e91-4962-83c7-4b6dc55c4818"), new Guid("1b0bc061-5262-437e-b662-b8635e0ef807"), "LivingRoomDoor", "Open", "StateIs", "ItemState" },
                    { new Guid("5ceed859-bad6-4a5a-a6aa-42ab55413708"), new Guid("1b78c171-dc4d-4d23-98ee-7cd29b27f260"), "BalconyDoor1", "Close", "StateIs", "ItemState" },
                    { new Guid("6c1d879e-4680-42b5-9f98-645b30628e8f"), new Guid("8f0c7f87-effd-41a9-95a5-74e65737a59f"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("717eebef-a7d2-4b20-94b1-117ae4f30dfe"), new Guid("9e87bc7a-820b-4e19-9e5f-c59b37d9a034"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("7eadc06e-4e07-4d62-9ca6-e874e115075d"), new Guid("1b78c171-dc4d-4d23-98ee-7cd29b27f260"), "Human1", "Bedroom1", "IsIn", "HumanPosition" },
                    { new Guid("863bc128-f6e6-4a41-8a3e-e4b2a607a333"), new Guid("bf561eff-18a0-4d19-9687-fbedcdfed65d"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("86eab1f4-b61b-4af0-92c1-fac07b9c4ea1"), new Guid("bf561eff-18a0-4d19-9687-fbedcdfed65d"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("950cc025-66f2-475a-bda1-9449e8658a7b"), new Guid("bf561eff-18a0-4d19-9687-fbedcdfed65d"), "TV", "Off", "StateIs", "ItemState" },
                    { new Guid("96c411a7-ffe4-40ea-bd3d-c872c6292b60"), new Guid("bdd1fe34-1872-4124-92c4-098815454a75"), "Human2", "Bedroom2", "IsIn", "HumanPosition" },
                    { new Guid("a001370b-92a0-4b6e-ab4f-495111cc47de"), new Guid("bdd1fe34-1872-4124-92c4-098815454a75"), "Bedroom1Door", "Close", "StateIs", "ItemState" },
                    { new Guid("ad0f8dc1-d3a0-43b4-9c2f-4b443d07be2e"), new Guid("8af11ed5-599d-404f-8fa6-5f7172c1378c"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("b2d38323-496c-4ea4-980f-9bfceba6bfd5"), new Guid("9e87bc7a-820b-4e19-9e5f-c59b37d9a034"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("b6b8badc-7d3e-49da-b26e-e1d660de0a91"), new Guid("8834a194-0000-409c-8d78-e096d022efc6"), "Human2", "Bedroom2", "IsIn", "HumanPosition" },
                    { new Guid("b730f329-92d9-4a60-8f32-f0db2e9b84fc"), new Guid("82aeab09-7832-463b-a7e9-5f1c62939906"), "BalconyWindow", "Open", "StateIs", "ItemState" },
                    { new Guid("bbebdc81-54ee-4bc3-9a0d-3c9c2f6fd86e"), new Guid("8834a194-0000-409c-8d78-e096d022efc6"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("bf9375fc-2933-4880-bc24-cf3cef0cf620"), new Guid("82aeab09-7832-463b-a7e9-5f1c62939906"), "Human1", "Sit", "StateIsNot", "HumanBodyStatus" },
                    { new Guid("c2836b81-8962-4396-ab5e-e9ccb0941ec8"), new Guid("ea59cf93-ca5b-41e1-bf45-f18524a0b2cb"), "LivingRoomDoor", "Close", "StateIs", "ItemState" },
                    { new Guid("c75493e8-284c-4cf4-a7af-3a19f455c82e"), new Guid("8f0c7f87-effd-41a9-95a5-74e65737a59f"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("c9ffbfff-e734-48ef-918b-4b51d806918d"), new Guid("e097576e-2eed-4e4f-9e45-4bbf9e9632a7"), "Human1", "Balcony", "IsIn", "HumanPosition" },
                    { new Guid("cace4a93-3703-47fd-b303-ac66cd1d5580"), new Guid("1b0bc061-5262-437e-b662-b8635e0ef807"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("cffc3d45-50f2-49de-8a8c-78e0376949fc"), new Guid("82aeab09-7832-463b-a7e9-5f1c62939906"), "Human1", "Tired", "StateIs", "MentalStatus" },
                    { new Guid("d4b0f944-0bbb-49cd-a5ad-dab6d4b8d92d"), new Guid("8834a194-0000-409c-8d78-e096d022efc6"), "Bedroom2Door", "Open", "StateIs", "ItemState" },
                    { new Guid("e79499b5-3d1e-4607-a3a6-1f616864a57f"), new Guid("1b78c171-dc4d-4d23-98ee-7cd29b27f260"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("eb0ae8f9-d799-4cba-b1fd-590a894ccb4b"), new Guid("ea59cf93-ca5b-41e1-bf45-f18524a0b2cb"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("f5bfb387-3c3d-4f72-9e94-e22df664399a"), new Guid("d97e1bc6-49f3-4f20-af2a-5ac18be5c38c"), "BalconyDoor1", "Open", "StateIs", "ItemState" }
                });

            migrationBuilder.InsertData(
                table: "ActionResult",
                columns: new[] { "Id", "ActionAggregateId", "CaseStudy", "ResultCaseChange", "ResultCaseType", "ResultType" },
                values: new object[,]
                {
                    { new Guid("03e8a9b7-6657-4296-b20b-62c81bc0deeb"), new Guid("8af11ed5-599d-404f-8fa6-5f7172c1378c"), "Human2", "Sit", "State", "HumanBodyStatus" },
                    { new Guid("2a53b0ec-0abb-417c-a6e8-8c4fbb003f3d"), new Guid("e097576e-2eed-4e4f-9e45-4bbf9e9632a7"), "BalconyWindow", "Open", "State", "ItemState" },
                    { new Guid("3653094b-335c-44f0-9da0-b785a3e7f5f2"), new Guid("8f0c7f87-effd-41a9-95a5-74e65737a59f"), "TV-Sound", "10-40", "Decrease", "ItemMetaData" },
                    { new Guid("3fe0a55a-8157-4ac3-9a54-9dc28f3b5f60"), new Guid("9e87bc7a-820b-4e19-9e5f-c59b37d9a034"), "Sound", "10-40", "Increase", "Environment" },
                    { new Guid("416af0bd-348d-49f1-8acc-b8999391d5fb"), new Guid("d97e1bc6-49f3-4f20-af2a-5ac18be5c38c"), "Human1", "25-81", "Position", "HumanPosition" },
                    { new Guid("43c2e62a-73bd-4afe-981c-ba7b4dab40f5"), new Guid("1b78c171-dc4d-4d23-98ee-7cd29b27f260"), "BalconyDoor1", "Open", "State", "ItemState" },
                    { new Guid("457c91b2-c153-4b14-947a-27adf376b08f"), new Guid("9e87bc7a-820b-4e19-9e5f-c59b37d9a034"), "TV-Sound", "10-40", "Increase", "ItemMetaData" },
                    { new Guid("488e1995-e228-43e2-9704-b50425a8b64f"), new Guid("bf561eff-18a0-4d19-9687-fbedcdfed65d"), "TV", "On", "State", "ItemState" },
                    { new Guid("5065084d-0225-46ea-82a5-298fab5f2d11"), new Guid("8834a194-0000-409c-8d78-e096d022efc6"), "Human2", "75-49", "Position", "HumanPosition" },
                    { new Guid("5e51d2b1-85c9-4785-a9d0-9fadf05a5dbb"), new Guid("8af11ed5-599d-404f-8fa6-5f7172c1378c"), "Sofa1", "Full", "State", "ItemState" },
                    { new Guid("62698ca2-6c7e-479a-b0c0-d62420c1e536"), new Guid("ea59cf93-ca5b-41e1-bf45-f18524a0b2cb"), "Human2", "55-31", "Position", "HumanPosition" },
                    { new Guid("755b5525-7fd4-4bd9-8c9e-3a3c49ec8a5e"), new Guid("bdd1fe34-1872-4124-92c4-098815454a75"), "Bedroom2Door", "Open", "State", "ItemState" },
                    { new Guid("7e8bf799-f75a-49e3-91c9-9efb7105c4db"), new Guid("e097576e-2eed-4e4f-9e45-4bbf9e9632a7"), "Human1", "50-99", "Position", "HumanPosition" },
                    { new Guid("83bae2e4-f9c5-4094-9cd5-4864c46d6665"), new Guid("9e87bc7a-820b-4e19-9e5f-c59b37d9a034"), "Light", "10", "Increase", "Environment" },
                    { new Guid("8b494fc2-f94d-46ff-a6b2-56786f13264f"), new Guid("1b0bc061-5262-437e-b662-b8635e0ef807"), "Human2", "55-29", "Position", "HumanPosition" },
                    { new Guid("a314fbe3-2c1a-48c0-8b52-cfe912fb747e"), new Guid("bdd1fe34-1872-4124-92c4-098815454a75"), "Human1", "75-51", "Position", "HumanPosition" },
                    { new Guid("a87e54d6-a369-49db-9e78-b999f12770df"), new Guid("82aeab09-7832-463b-a7e9-5f1c62939906"), "Human1", "Normal", "State", "MentalStatus" },
                    { new Guid("b088be9b-77c5-4ff5-a122-1e1685bba303"), new Guid("8f0c7f87-effd-41a9-95a5-74e65737a59f"), "Sound", "10-40", "Decrease", "Environment" },
                    { new Guid("bf17bae9-7505-4d7c-838a-0b8806bfc81e"), new Guid("ea59cf93-ca5b-41e1-bf45-f18524a0b2cb"), "LivingRoomDoor", "Open", "State", "ItemState" },
                    { new Guid("c1ba1f9c-9f10-4668-8e84-430bc422e8f5"), new Guid("82aeab09-7832-463b-a7e9-5f1c62939906"), "Human1", "Sit", "State", "HumanBodyStatus" },
                    { new Guid("c794c716-9ca6-4270-ba48-2f650a440562"), new Guid("8f0c7f87-effd-41a9-95a5-74e65737a59f"), "Light", "10", "Increase", "Environment" },
                    { new Guid("d0884089-1376-4ca9-94fd-8074382f4ed7"), new Guid("1b78c171-dc4d-4d23-98ee-7cd29b27f260"), "Human1", "25-79", "Position", "HumanPosition" },
                    { new Guid("dab5b6c7-48db-4f73-a664-10af93994ec6"), new Guid("bf561eff-18a0-4d19-9687-fbedcdfed65d"), "Human2", "Normal", "State", "MentalStatus" },
                    { new Guid("dd6701b5-480a-4947-864c-19a782f5db7f"), new Guid("8af11ed5-599d-404f-8fa6-5f7172c1378c"), "Human2", "70-20", "Position", "HumanPosition" },
                    { new Guid("f95788bc-d1bd-45b9-80f7-d5ad17e57e65"), new Guid("e097576e-2eed-4e4f-9e45-4bbf9e9632a7"), "Light", "20-IF:Day", "Increase", "Environment" }
                });

            migrationBuilder.InsertData(
                table: "NextAction",
                columns: new[] { "Id", "ActionAggregateId", "Delay", "Possibility" },
                values: new object[,]
                {
                    { new Guid("1b0bc061-5262-437e-b662-b8635e0ef807"), new Guid("ea59cf93-ca5b-41e1-bf45-f18524a0b2cb"), 200, 100 },
                    { new Guid("82aeab09-7832-463b-a7e9-5f1c62939906"), new Guid("e097576e-2eed-4e4f-9e45-4bbf9e9632a7"), 100, 100 },
                    { new Guid("8834a194-0000-409c-8d78-e096d022efc6"), new Guid("bdd1fe34-1872-4124-92c4-098815454a75"), 200, 100 },
                    { new Guid("8af11ed5-599d-404f-8fa6-5f7172c1378c"), new Guid("1b0bc061-5262-437e-b662-b8635e0ef807"), 200, 100 },
                    { new Guid("8f0c7f87-effd-41a9-95a5-74e65737a59f"), new Guid("bf561eff-18a0-4d19-9687-fbedcdfed65d"), 200, 100 },
                    { new Guid("9e87bc7a-820b-4e19-9e5f-c59b37d9a034"), new Guid("bf561eff-18a0-4d19-9687-fbedcdfed65d"), 200, 100 },
                    { new Guid("bf561eff-18a0-4d19-9687-fbedcdfed65d"), new Guid("8af11ed5-599d-404f-8fa6-5f7172c1378c"), 200, 100 },
                    { new Guid("d97e1bc6-49f3-4f20-af2a-5ac18be5c38c"), new Guid("1b78c171-dc4d-4d23-98ee-7cd29b27f260"), 200, 100 },
                    { new Guid("e097576e-2eed-4e4f-9e45-4bbf9e9632a7"), new Guid("d97e1bc6-49f3-4f20-af2a-5ac18be5c38c"), 200, 100 },
                    { new Guid("ea59cf93-ca5b-41e1-bf45-f18524a0b2cb"), new Guid("8834a194-0000-409c-8d78-e096d022efc6"), 200, 100 }
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
