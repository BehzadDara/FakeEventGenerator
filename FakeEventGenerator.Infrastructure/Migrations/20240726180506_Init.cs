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
                    EndPossibility = table.Column<int>(type: "int", nullable: false)
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
                    Location = table.Column<int>(type: "int", nullable: false),
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
                    Location = table.Column<int>(type: "int", nullable: false),
                    IsMovable = table.Column<bool>(type: "bit", nullable: false),
                    MetaData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
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
                columns: new[] { "Id", "Delay", "Description", "EndPossibility", "Name" },
                values: new object[,]
                {
                    { new Guid("016d426a-2566-42a6-8796-2244e6f377ec"), 500, "Move To Corridor Human2 Via Bedroom2", 100, "Move-Corridor-Bedroom1" },
                    { new Guid("09c8455e-3eef-4036-994b-bf7ce39bf235"), 1500, "Open Door Of Bedroom2", 100, "Open-Bedroom2Door" },
                    { new Guid("0d777c34-dd39-4252-9f64-8d67a448fd64"), 200, "Decrease Degree Of AirConditioner3", 100, "Decrease-Degree" },
                    { new Guid("23105c78-b2e5-4d0a-8c36-25941b402dac"), 1500, "Open SafeBox", 0, "Open-SafeBox" },
                    { new Guid("31d83d8e-871e-4f2b-aa34-073258580722"), 100, "Move To LivingRoom Human2 Via Corridor", 100, "Move-LivingRoom-Corridor" },
                    { new Guid("3ff70002-1fd6-401b-8f7e-dad3253cc7fc"), 350, "Increase Sound Of TV", 100, "Increase-Sound" },
                    { new Guid("509c51f0-8991-42e7-bd9f-8c26070d89b6"), 2400, "Move to corridor via livingroom", 50, "Move-Corridor-LivingRoom" },
                    { new Guid("54e3ecd1-47a4-41db-a036-2402c74ae7ed"), 350, "Decrease Sound Of TV", 100, "Decrease-Sound" },
                    { new Guid("75ea5975-decd-4a20-863b-52fc9e582d43"), 50, "Sit Under BalconyWindow", 100, "Sit-BalconyWindow" },
                    { new Guid("8374b387-564a-46f1-8fe2-0d2da584eb4e"), 500, "Move to kitchen form corridor", 100, "Move-Kitchen-Corridor" },
                    { new Guid("890c48e6-5ef6-494e-a2c4-553669331ca3"), 1000, "Close SafeBox", 0, "Close-SafeBox" },
                    { new Guid("90f6ccf8-707d-4873-a4bf-f41b27610820"), 400, "Open Door Of LivingRoom", 100, "Open-LivinRoomDoor" },
                    { new Guid("a1d6d20f-b4de-4d59-a3eb-a8b16811f2a4"), 500, "Open Door1 Of Balcony", 100, "Open-BalconyDoor1" },
                    { new Guid("afc68b69-be7b-4ac2-9f4a-e27c251897e9"), 600, "Turn On AirConditioner3", 100, "On-AirConditioner3" },
                    { new Guid("b62ca4c5-73ca-462f-a89d-46e42f4fa4b9"), 1100, "Open door of the kitchen", 100, "Open-Kitchen-Door" },
                    { new Guid("db116b9c-e998-498f-9ca3-f4e8eeeb4b8b"), 200, "Human2 Stand In LivingRoom", 100, "Stand-LivingRoom" },
                    { new Guid("dd1f9853-c241-4258-8059-cdf5e1432d34"), 800, "Sit On Sofa1", 100, "Sit-Sofa1" },
                    { new Guid("e06f8346-a23c-4523-842f-729f25ddbb44"), 500, "Move To Balcony Human1 Via Bedroom1", 100, "Move-Balcony-Bedroom1" },
                    { new Guid("e75a58c7-d48b-4c43-8d2d-d439c8e86578"), 100, "Open Window Of Balcony", 100, "Open-BalconyWindow" },
                    { new Guid("f1992220-dfad-4d92-867f-fec102e47f0a"), 200, "Turn On TV", 50, "On-TV" }
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
                columns: new[] { "Id", "BodyStatus", "FeelToDegree", "Location", "MentalStatus", "Name" },
                values: new object[,]
                {
                    { new Guid("b0f8f125-97c8-41a9-a485-63fa4b31ca8c"), "Stand", "Medium", 3, "Bored", "Human2" },
                    { new Guid("c21ee14b-6e26-4ae3-a424-b54267987143"), "Stand", "Medium", 2, "Tired", "Human1" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Description", "IsMovable", "Location", "MetaData", "Name", "State", "Type" },
                values: new object[,]
                {
                    { new Guid("0697dc50-b75a-44d0-8c63-e0f9f7666e5d"), "Bathroom Door", false, 4, "", "BathroomDoor", "Close", "Openable" },
                    { new Guid("13a25653-a6bf-4ee1-b33c-8177bb066bc0"), "Balcony Door1", false, 5, "", "BalconyDoor1", "Close", "Openable" },
                    { new Guid("13ec032b-28a6-4fb7-965e-76d676117714"), "LivingRoom Lamp", false, 0, "", "Lamp4", "Off", "Electronic" },
                    { new Guid("15bf35d9-190d-4343-bb81-888dd37fe4a6"), "Bedroom1 AirConditioner", false, 2, "", "AirConditioner1", "Off", "Electronic" },
                    { new Guid("171ba84f-d703-46d1-9edf-ba526ce67ebb"), "Bedroom2 Chair", false, 3, "", "Chair21", "NotBeUsing", "Usable" },
                    { new Guid("1e83cfb2-7d44-4b8d-9c70-f611c4c6924d"), "Corridor Lamp", false, 6, "", "Lamp7", "Off", "Electronic" },
                    { new Guid("2e21e329-b5f5-48d9-a361-c8164e9da993"), "Bedroom1 Lamp", false, 2, "{\"Severity\":20}", "Lamp1", "Off", "Electronic" },
                    { new Guid("2f2cbc08-ee50-4128-a4cf-7a89bcf971ef"), "Kitchen WashingMachine", false, 1, "", "WashingMachine", "NotBeUsing", "Usable" },
                    { new Guid("3570154f-185d-4454-816e-0e5763c4e598"), "Bedroom2 Window", false, 3, "", "Bedroom2Window", "Close", "Openable" },
                    { new Guid("36b103b6-e2be-4744-8507-525418aa208b"), "Bedroom1 Chair", false, 2, "", "Chair11", "NotBeUsing", "Usable" },
                    { new Guid("3e985ba4-1e87-4741-a204-28a9049bc57b"), "LivingRoom Sofa1", false, 0, "{\"Capacity\":1}", "Sofa1", "NotFull", "UseWithCapacity" },
                    { new Guid("3ed8f519-27f8-4eaa-89da-1afe8011dc37"), "Bedroom2 Door", false, 3, "", "Bedroom2Door", "Close", "Openable" },
                    { new Guid("473e4f87-aead-4adc-bb4a-3eeddfd93788"), "Bedroom2 Bed", false, 3, "{\"Temperature\":20,\"Speed\":10}", "Bedroom2Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("4fd24168-e0d2-4a0a-9146-ec8684c76183"), "LivingRoom Door", false, 0, "", "LivingRoomDoor", "Close", "Openable" },
                    { new Guid("56df0284-2600-4399-a0b7-c517cc2711b0"), "Bedroom1 Bed", false, 2, "", "Bedroom1Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("56f31d65-1489-4083-b902-3991d2b002f3"), "LivingRoom Chair4", false, 0, "", "Chair4", "NotBeUsing", "Usable" },
                    { new Guid("5befc2e4-9a34-4081-aa74-04b4489c9d00"), "LivingRoom Chair2", false, 0, "", "Chair2", "NotBeUsing", "Usable" },
                    { new Guid("6dd43a57-bb60-4842-8dea-6a518817b2e3"), "LivingRoom Table", false, 0, "", "Table", "NotBeUsing", "Usable" },
                    { new Guid("70e8f659-0a29-4c36-8f71-dd5c97d1b0b8"), "LivingRoom Chair3", false, 0, "", "Chair3", "NotBeUsing", "Usable" },
                    { new Guid("71d605ae-d911-40ce-a8a8-e8b656c122db"), "Kitchen DishWasher", false, 1, "", "DishWasher", "NotBeUsing", "Usable" },
                    { new Guid("7519c829-18ef-476e-a985-edbbf264499d"), "Bathroom Lamp", false, 4, "", "Lamp5", "Off", "Electronic" },
                    { new Guid("79d7ce5e-c051-42ae-9a62-273bbaa7b5d4"), "Bedroom1 Computer", false, 2, "", "Computer", "Off", "Electronic" },
                    { new Guid("90683171-af93-43e2-8925-7a54edee65cc"), "LivingRoom TV", false, 0, "{\"Channel\":1,\"Sound\":60}", "TV", "Off", "Electronic" },
                    { new Guid("9830c37b-a75e-43d6-b7d5-c24f32ff479e"), "LivingRoom Sofa2", false, 0, "{\"Capacity\":2}", "Sofa2", "NotFull", "UseWithCapacity" },
                    { new Guid("9ae6edf2-e98a-4086-854b-8a650269a968"), "Kitchen Door", false, 1, "", "KitchenDoor", "Close", "Openable" },
                    { new Guid("9fd8a48a-cf06-45d5-b5f8-26ad9d6d3c94"), "LivingRoom AirConditioner", false, 0, "{\"Temperature\":20,\"Speed\":10}", "AirConditioner3", "Off", "Electronic" },
                    { new Guid("af743ea5-df2b-4ef4-abe2-e9b385d0db1c"), "Kitchen Oven", false, 1, "", "Oven", "NotBeUsing", "Usable" },
                    { new Guid("b18f392f-e54c-44d8-be26-29fe4def565f"), "House Door", false, 0, "", "HouseDoor", "Close", "Openable" },
                    { new Guid("b9ce9676-f875-4b4c-b3dc-ed4f14d01646"), "Bedroom2 Laptop", true, 3, "{\"Charge\":90,\"IsInCharge\":false}", "Laptop", "Off", "Electronic" },
                    { new Guid("bc024886-b45f-406c-a24e-7332d0c12bbf"), "Balcony Lamp", false, 5, "", "Lamp6", "Off", "Electronic" },
                    { new Guid("c630cb1c-c865-46dd-a23e-87f5629d5733"), "Bedroom1 Window", false, 2, "", "Bedroom1Window", "Close", "Openable" },
                    { new Guid("c7e85d25-3424-45fc-bb28-3ee2ad11fcaf"), "Bedroom2 Lamp", false, 3, "{\"Severity\":20}", "Lamp2", "Off", "Electronic" },
                    { new Guid("ca732900-d773-428e-9752-4b33b154fed9"), "Bedroom2 AirConditioner", false, 3, "{\"Temperature\":20,\"Speed\":10}", "AirConditioner2", "Off", "Electronic" },
                    { new Guid("cee7ab00-9d06-4438-ac8c-172f2f6bf3aa"), "Balcony Door2", false, 5, "", "BalconyDoor2", "Close", "Openable" },
                    { new Guid("d560a918-703e-40e2-83b5-c412526a301e"), "LivingRoom Sofa3", false, 0, "{\"Capacity\":3}", "Sofa3", "NotFull", "UseWithCapacity" },
                    { new Guid("e608c193-6792-4fbd-80f6-788337916592"), "Safe Box", false, 6, "", "SafeBox", "Close", "Openable" },
                    { new Guid("ec977a0a-86cb-4746-953c-0fc191bc3c15"), "LivingRoom Chair1", false, 0, "", "Chair1", "NotBeUsing", "Usable" },
                    { new Guid("ef0dc462-dee7-46ba-8a67-f13946f78b90"), "Kitchen Lamp", false, 1, "", "Lamp3", "Off", "Electronic" },
                    { new Guid("ef3c4eb2-d8ac-48cf-a090-76e4a4a52bb0"), "Kitchen Refrigerator", false, 1, "", "Refrigerator", "Close", "Openable" },
                    { new Guid("f2d36c8c-7cb4-4ac1-97f1-4bf6e9bc45b6"), "Bedroom1 Door", false, 2, "", "Bedroom1Door", "Close", "Openable" },
                    { new Guid("feb8d427-d1ca-4a01-9a1b-1de8f15f4596"), "Balcony Window", false, 5, "", "BalconyWindow", "Close", "Openable" }
                });

            migrationBuilder.InsertData(
                table: "ActionCondition",
                columns: new[] { "Id", "ActionAggregateId", "CaseStudy", "ConditionCaseExpectation", "ConditionCaseType", "ConditionType" },
                values: new object[,]
                {
                    { new Guid("04aa0cbc-a528-4df5-9a2b-fa7d48fb156e"), new Guid("e06f8346-a23c-4523-842f-729f25ddbb44"), "BalconyDoor1", "Open", "StateIs", "ItemState" },
                    { new Guid("0b338e8b-075e-4453-98f2-ce3bc0f3c857"), new Guid("09c8455e-3eef-4036-994b-bf7ce39bf235"), "Human2", "Bedroom2", "IsIn", "HumanPosition" },
                    { new Guid("1673317e-54b3-41c2-b4eb-16fe9bbcdcf4"), new Guid("75ea5975-decd-4a20-863b-52fc9e582d43"), "Human1", "Tired", "StateIs", "MentalStatus" },
                    { new Guid("176f7753-e46d-4aa2-a668-e3019c5b37f2"), new Guid("0d777c34-dd39-4252-9f64-8d67a448fd64"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("1a16ecf6-960f-4243-9084-dbe8d0f50166"), new Guid("31d83d8e-871e-4f2b-aa34-073258580722"), "LivingRoomDoor", "Open", "StateIs", "ItemState" },
                    { new Guid("1a2a793b-82ad-48f8-bc1d-72d629de6ea8"), new Guid("f1992220-dfad-4d92-867f-fec102e47f0a"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("2dbbc7f0-8dda-4cb9-b420-395713292377"), new Guid("75ea5975-decd-4a20-863b-52fc9e582d43"), "Human1", "Balcony", "IsIn", "HumanPosition" },
                    { new Guid("35160ffe-e5e3-4180-ba24-ad397949c1fe"), new Guid("75ea5975-decd-4a20-863b-52fc9e582d43"), "Human1", "Sit", "StateIsNot", "HumanBodyStatus" },
                    { new Guid("3aa212e8-0136-4bd1-9230-513678860098"), new Guid("75ea5975-decd-4a20-863b-52fc9e582d43"), "BalconyWindow", "Open", "StateIs", "ItemState" },
                    { new Guid("3d13d3ce-d59d-46f4-a307-b24afd9278d9"), new Guid("dd1f9853-c241-4258-8059-cdf5e1432d34"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("4d77814a-077c-412d-83ab-b90fcbcfc180"), new Guid("e75a58c7-d48b-4c43-8d2d-d439c8e86578"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("50c14b0d-56cf-41e5-91dd-5e04c67b084e"), new Guid("54e3ecd1-47a4-41db-a036-2402c74ae7ed"), "TV", "On", "StateIs", "ItemState" },
                    { new Guid("5bb44c74-9ec4-4502-9ae0-57b06bac4c7d"), new Guid("54e3ecd1-47a4-41db-a036-2402c74ae7ed"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("5be59fa4-fed7-40a8-8b18-359d56696e3b"), new Guid("afc68b69-be7b-4ac2-9f4a-e27c251897e9"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("5e1e6949-68d9-4266-bd0d-510215750356"), new Guid("23105c78-b2e5-4d0a-8c36-25941b402dac"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("5ebe1d82-5c09-4f99-bd37-2e8bcf76cfad"), new Guid("54e3ecd1-47a4-41db-a036-2402c74ae7ed"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("6b51cbe5-6ced-405e-9619-3a80d2a5f446"), new Guid("09c8455e-3eef-4036-994b-bf7ce39bf235"), "Bedroom1Door", "Close", "StateIs", "ItemState" },
                    { new Guid("6dc69896-07d4-42d0-b524-aa65795a6f2f"), new Guid("90f6ccf8-707d-4873-a4bf-f41b27610820"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("72c228f9-25e1-4576-9d69-610eab6b669f"), new Guid("0d777c34-dd39-4252-9f64-8d67a448fd64"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("72cad0d3-64f8-4f7a-87c1-56412182bcd5"), new Guid("90f6ccf8-707d-4873-a4bf-f41b27610820"), "LivingRoomDoor", "Close", "StateIs", "ItemState" },
                    { new Guid("79554513-d70a-4930-a0cc-b3c4e1cf08dd"), new Guid("afc68b69-be7b-4ac2-9f4a-e27c251897e9"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("7af5037f-360c-4777-947f-7dee5e4d29cd"), new Guid("8374b387-564a-46f1-8fe2-0d2da584eb4e"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("7ef8a35a-3e34-4568-9e65-f68d24684ddb"), new Guid("016d426a-2566-42a6-8796-2244e6f377ec"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("83e192d0-624c-4fbf-bbe7-c588fddcdfc0"), new Guid("016d426a-2566-42a6-8796-2244e6f377ec"), "Human2", "Bedroom2", "IsIn", "HumanPosition" },
                    { new Guid("84998220-35e8-4ce7-9b72-d5530bc9638f"), new Guid("dd1f9853-c241-4258-8059-cdf5e1432d34"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("918e721d-9136-4889-be6a-75c0e962fc74"), new Guid("31d83d8e-871e-4f2b-aa34-073258580722"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("9b3333d2-15ec-407d-9487-160bbe4d3d62"), new Guid("db116b9c-e998-498f-9ca3-f4e8eeeb4b8b"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("9e23e601-128e-4933-8201-963f45da65b4"), new Guid("3ff70002-1fd6-401b-8f7e-dad3253cc7fc"), "TV", "On", "StateIs", "ItemState" },
                    { new Guid("a048ed34-99f9-40de-bf20-a3c8bea58fbb"), new Guid("f1992220-dfad-4d92-867f-fec102e47f0a"), "TV", "Off", "StateIs", "ItemState" },
                    { new Guid("a34fdac7-8f12-4285-98b5-ddff19462556"), new Guid("b62ca4c5-73ca-462f-a89d-46e42f4fa4b9"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("a40849c6-0205-48ce-9ff2-6bc3df51185a"), new Guid("0d777c34-dd39-4252-9f64-8d67a448fd64"), "AirConditioner3", "On", "StateIs", "ItemState" },
                    { new Guid("a812f3c4-a49a-4240-b871-007bcf591352"), new Guid("e06f8346-a23c-4523-842f-729f25ddbb44"), "Human1", "Bedroom1", "IsIn", "HumanPosition" },
                    { new Guid("ae0c53a8-3bce-4c2d-a3b2-268fbe7dde01"), new Guid("509c51f0-8991-42e7-bd9f-8c26070d89b6"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("b8ff6707-705c-475d-a507-4644f138e143"), new Guid("e75a58c7-d48b-4c43-8d2d-d439c8e86578"), "Human1", "Balcony", "IsIn", "HumanPosition" },
                    { new Guid("c6da2934-6898-4201-8f10-294dd4e48338"), new Guid("e06f8346-a23c-4523-842f-729f25ddbb44"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("ccb228a8-905f-4139-9011-6effc4e3a87f"), new Guid("90f6ccf8-707d-4873-a4bf-f41b27610820"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("d7c28e01-1e28-4428-b975-a473911e09ae"), new Guid("a1d6d20f-b4de-4d59-a3eb-a8b16811f2a4"), "BalconyDoor1", "Close", "StateIs", "ItemState" },
                    { new Guid("d9d6fb3a-fa95-4367-a73c-f1bac6ba7bb2"), new Guid("8374b387-564a-46f1-8fe2-0d2da584eb4e"), "KitchenDoor", "Open", "StateIs", "ItemState" },
                    { new Guid("daf0d027-7451-458e-b4a5-4ea51bad01ad"), new Guid("db116b9c-e998-498f-9ca3-f4e8eeeb4b8b"), "Human2", "Stand", "StateIsNot", "HumanBodyStatus" },
                    { new Guid("ddff0144-ec0f-49c2-89c4-16e53f72fcaa"), new Guid("a1d6d20f-b4de-4d59-a3eb-a8b16811f2a4"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("e07b4b4f-521a-4ca6-ad72-ffcf96743177"), new Guid("f1992220-dfad-4d92-867f-fec102e47f0a"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("e12e91c4-83e4-4ed3-beff-200d98696051"), new Guid("3ff70002-1fd6-401b-8f7e-dad3253cc7fc"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("e3b591e1-33a0-4ef5-806e-2d55b78712dd"), new Guid("31d83d8e-871e-4f2b-aa34-073258580722"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("ea6c82f3-7bb9-4397-8173-982a4129b8a5"), new Guid("016d426a-2566-42a6-8796-2244e6f377ec"), "Bedroom2Door", "Open", "StateIs", "ItemState" },
                    { new Guid("f5afb842-d40e-4559-973f-06b99b19908a"), new Guid("a1d6d20f-b4de-4d59-a3eb-a8b16811f2a4"), "Human1", "Bedroom1", "IsIn", "HumanPosition" },
                    { new Guid("f708db86-11b9-4719-a034-dfcc3155255f"), new Guid("890c48e6-5ef6-494e-a2c4-553669331ca3"), "SafeBox", "Open", "StateIs", "ItemState" },
                    { new Guid("f7f0598d-42f7-45a4-aca2-f301c657364b"), new Guid("09c8455e-3eef-4036-994b-bf7ce39bf235"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("fb335ea8-f8fe-4240-9aba-cd7b68133677"), new Guid("3ff70002-1fd6-401b-8f7e-dad3253cc7fc"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("ff6119f2-4270-4b66-babf-60185904a187"), new Guid("890c48e6-5ef6-494e-a2c4-553669331ca3"), "Human2", "Corridor", "IsIn", "HumanPosition" }
                });

            migrationBuilder.InsertData(
                table: "ActionResult",
                columns: new[] { "Id", "ActionAggregateId", "CaseStudy", "ResultCaseChange", "ResultCaseType", "ResultType" },
                values: new object[,]
                {
                    { new Guid("19077f58-7c6a-49f0-9775-e9db8fc04bca"), new Guid("db116b9c-e998-498f-9ca3-f4e8eeeb4b8b"), "Human2", "Stand", "State", "HumanBodyStatus" },
                    { new Guid("1d40b181-8fbf-4d12-b3e9-91bcbd0d061a"), new Guid("f1992220-dfad-4d92-867f-fec102e47f0a"), "Human2", "Normal", "State", "MentalStatus" },
                    { new Guid("2221a339-f58f-49eb-ad14-84d50d64e1e1"), new Guid("e75a58c7-d48b-4c43-8d2d-d439c8e86578"), "Human1", "Balcony", "Position", "HumanPosition" },
                    { new Guid("23e3ed81-55fa-4555-8101-e5a792fcafb8"), new Guid("09c8455e-3eef-4036-994b-bf7ce39bf235"), "Human1", "Bedroom2", "Position", "HumanPosition" },
                    { new Guid("30a1930b-c815-4847-b370-f71c412d802d"), new Guid("0d777c34-dd39-4252-9f64-8d67a448fd64"), "Human2", "Cold", "State", "HumanFeelToDegree" },
                    { new Guid("357780ee-2afe-487b-8516-e9dadfe23104"), new Guid("75ea5975-decd-4a20-863b-52fc9e582d43"), "Human1", "Sit", "State", "HumanBodyStatus" },
                    { new Guid("381f5caa-a8ff-4d1a-8939-f804d84ab940"), new Guid("54e3ecd1-47a4-41db-a036-2402c74ae7ed"), "Sound", "10-40", "Decrease", "Environment" },
                    { new Guid("40b6ccb6-dac5-4e37-8b59-cb04fc935be2"), new Guid("b62ca4c5-73ca-462f-a89d-46e42f4fa4b9"), "KitchenDoor", "Open", "State", "ItemState" },
                    { new Guid("47784418-2658-4ea1-82f1-c51438d68f1e"), new Guid("a1d6d20f-b4de-4d59-a3eb-a8b16811f2a4"), "Human1", "Bedroom1", "Position", "HumanPosition" },
                    { new Guid("4892b86a-225b-4161-aa1c-48e00776fb4d"), new Guid("e75a58c7-d48b-4c43-8d2d-d439c8e86578"), "Light", "20-IF:Day", "Increase", "Environment" },
                    { new Guid("5364949c-6c41-4a97-8842-d15b8f683959"), new Guid("509c51f0-8991-42e7-bd9f-8c26070d89b6"), "Human2", "Corridor", "Position", "HumanPosition" },
                    { new Guid("5559a659-23b7-437b-99fb-931b259c651a"), new Guid("afc68b69-be7b-4ac2-9f4a-e27c251897e9"), "AirConditioner3", "On", "State", "ItemState" },
                    { new Guid("673c44ce-8e5e-40d6-986e-6c96b4389042"), new Guid("e75a58c7-d48b-4c43-8d2d-d439c8e86578"), "BalconyWindow", "Open", "State", "ItemState" },
                    { new Guid("6a0a3fd6-88bc-4f9a-b3b8-207f556a4f24"), new Guid("54e3ecd1-47a4-41db-a036-2402c74ae7ed"), "Light", "10", "Increase", "Environment" },
                    { new Guid("720374ab-826f-4d80-aaf1-27779c57631b"), new Guid("e06f8346-a23c-4523-842f-729f25ddbb44"), "Human1", "Balcony", "Position", "HumanPosition" },
                    { new Guid("746402cd-9dca-43ef-ae5a-ae07387796b5"), new Guid("09c8455e-3eef-4036-994b-bf7ce39bf235"), "Bedroom2Door", "Open", "State", "ItemState" },
                    { new Guid("752deb28-cb70-4f66-9982-87c1f1ea49b8"), new Guid("3ff70002-1fd6-401b-8f7e-dad3253cc7fc"), "TV-Sound", "10-40", "Increase", "ItemMetaData" },
                    { new Guid("80e16184-bbaf-4323-bdef-17ac8823e646"), new Guid("90f6ccf8-707d-4873-a4bf-f41b27610820"), "Human2", "Corridor", "Position", "HumanPosition" },
                    { new Guid("839c68ce-a0aa-42da-9ecd-c344555d2445"), new Guid("dd1f9853-c241-4258-8059-cdf5e1432d34"), "Human2", "Sit", "State", "HumanBodyStatus" },
                    { new Guid("8af08c33-db4b-447b-a2d7-4636a45b2e92"), new Guid("afc68b69-be7b-4ac2-9f4a-e27c251897e9"), "Human2", "LivingRoom", "Position", "HumanPosition" },
                    { new Guid("8bcf30c7-3aea-440b-9b8e-121d437192cd"), new Guid("dd1f9853-c241-4258-8059-cdf5e1432d34"), "Human2", "LivingRoom", "Position", "HumanPosition" },
                    { new Guid("909d51bb-b5b6-49cc-9470-eb4752fd6ede"), new Guid("0d777c34-dd39-4252-9f64-8d67a448fd64"), "Degree", "7", "Decrease", "Environment" },
                    { new Guid("911f0585-a81a-4071-9725-6d1baec10937"), new Guid("016d426a-2566-42a6-8796-2244e6f377ec"), "Human2", "Corridor", "Position", "HumanPosition" },
                    { new Guid("9f175cb2-590b-424f-80fa-202112c9e7b1"), new Guid("3ff70002-1fd6-401b-8f7e-dad3253cc7fc"), "Light", "10", "Increase", "Environment" },
                    { new Guid("a049277a-811d-44e8-8824-16779a2da720"), new Guid("31d83d8e-871e-4f2b-aa34-073258580722"), "Human2", "LivingRoom", "Position", "HumanPosition" },
                    { new Guid("af1a0847-5936-456b-ad85-324742fa433e"), new Guid("75ea5975-decd-4a20-863b-52fc9e582d43"), "Human1", "Normal", "State", "MentalStatus" },
                    { new Guid("b502a886-40f3-4961-a18d-dbc18112786c"), new Guid("8374b387-564a-46f1-8fe2-0d2da584eb4e"), "Human2", "Kitchen", "Position", "HumanPosition" },
                    { new Guid("b79ef17b-acd3-4c7b-9f5b-8620d9b9689b"), new Guid("54e3ecd1-47a4-41db-a036-2402c74ae7ed"), "TV-Sound", "10-40", "Decrease", "ItemMetaData" },
                    { new Guid("be15eefa-3c05-45f7-a568-e90306a94060"), new Guid("3ff70002-1fd6-401b-8f7e-dad3253cc7fc"), "Sound", "10-40", "Increase", "Environment" },
                    { new Guid("c51e6a74-c022-458a-829b-4702c429e0be"), new Guid("90f6ccf8-707d-4873-a4bf-f41b27610820"), "LivingRoomDoor", "Open", "State", "ItemState" },
                    { new Guid("c70e9d2c-deb4-47d3-a858-726c63dc48a0"), new Guid("dd1f9853-c241-4258-8059-cdf5e1432d34"), "Sofa1", "Full", "State", "ItemState" },
                    { new Guid("dd191aa2-f877-4852-b593-cc6efd0e33b1"), new Guid("f1992220-dfad-4d92-867f-fec102e47f0a"), "TV", "On", "State", "ItemState" },
                    { new Guid("df69005a-e29f-40e2-bbf6-5ae756608a5c"), new Guid("a1d6d20f-b4de-4d59-a3eb-a8b16811f2a4"), "BalconyDoor1", "Open", "State", "ItemState" },
                    { new Guid("dfd2a195-7b7d-4378-a6b4-bf8b09ef2ee7"), new Guid("890c48e6-5ef6-494e-a2c4-553669331ca3"), "SafeBox", "Close", "State", "ItemState" },
                    { new Guid("ebaa547b-5016-4c67-8ad5-6c9f2e389ef8"), new Guid("0d777c34-dd39-4252-9f64-8d67a448fd64"), "AirConditioner3-Temperature", "5-15", "Decrease", "ItemMetaData" },
                    { new Guid("f408b157-2440-4ba4-9084-56cc94c20d18"), new Guid("23105c78-b2e5-4d0a-8c36-25941b402dac"), "SafeBox", "Open", "State", "ItemState" }
                });

            migrationBuilder.InsertData(
                table: "NextAction",
                columns: new[] { "ActionAggregateId", "Id", "Delay", "Possibility" },
                values: new object[,]
                {
                    { new Guid("09c8455e-3eef-4036-994b-bf7ce39bf235"), new Guid("016d426a-2566-42a6-8796-2244e6f377ec"), 200, 100 },
                    { new Guid("afc68b69-be7b-4ac2-9f4a-e27c251897e9"), new Guid("0d777c34-dd39-4252-9f64-8d67a448fd64"), 200, 10 },
                    { new Guid("016d426a-2566-42a6-8796-2244e6f377ec"), new Guid("23105c78-b2e5-4d0a-8c36-25941b402dac"), 150, 50 },
                    { new Guid("90f6ccf8-707d-4873-a4bf-f41b27610820"), new Guid("31d83d8e-871e-4f2b-aa34-073258580722"), 200, 100 },
                    { new Guid("f1992220-dfad-4d92-867f-fec102e47f0a"), new Guid("3ff70002-1fd6-401b-8f7e-dad3253cc7fc"), 200, 100 },
                    { new Guid("890c48e6-5ef6-494e-a2c4-553669331ca3"), new Guid("509c51f0-8991-42e7-bd9f-8c26070d89b6"), 600, 100 },
                    { new Guid("f1992220-dfad-4d92-867f-fec102e47f0a"), new Guid("54e3ecd1-47a4-41db-a036-2402c74ae7ed"), 200, 100 },
                    { new Guid("e75a58c7-d48b-4c43-8d2d-d439c8e86578"), new Guid("75ea5975-decd-4a20-863b-52fc9e582d43"), 100, 100 },
                    { new Guid("b62ca4c5-73ca-462f-a89d-46e42f4fa4b9"), new Guid("8374b387-564a-46f1-8fe2-0d2da584eb4e"), 300, 100 },
                    { new Guid("23105c78-b2e5-4d0a-8c36-25941b402dac"), new Guid("890c48e6-5ef6-494e-a2c4-553669331ca3"), 1800, 100 },
                    { new Guid("016d426a-2566-42a6-8796-2244e6f377ec"), new Guid("90f6ccf8-707d-4873-a4bf-f41b27610820"), 200, 50 },
                    { new Guid("31d83d8e-871e-4f2b-aa34-073258580722"), new Guid("afc68b69-be7b-4ac2-9f4a-e27c251897e9"), 350, 70 },
                    { new Guid("db116b9c-e998-498f-9ca3-f4e8eeeb4b8b"), new Guid("afc68b69-be7b-4ac2-9f4a-e27c251897e9"), 200, 100 },
                    { new Guid("509c51f0-8991-42e7-bd9f-8c26070d89b6"), new Guid("b62ca4c5-73ca-462f-a89d-46e42f4fa4b9"), 200, 100 },
                    { new Guid("31d83d8e-871e-4f2b-aa34-073258580722"), new Guid("dd1f9853-c241-4258-8059-cdf5e1432d34"), 200, 30 },
                    { new Guid("afc68b69-be7b-4ac2-9f4a-e27c251897e9"), new Guid("dd1f9853-c241-4258-8059-cdf5e1432d34"), 200, 90 },
                    { new Guid("a1d6d20f-b4de-4d59-a3eb-a8b16811f2a4"), new Guid("e06f8346-a23c-4523-842f-729f25ddbb44"), 200, 100 },
                    { new Guid("e06f8346-a23c-4523-842f-729f25ddbb44"), new Guid("e75a58c7-d48b-4c43-8d2d-d439c8e86578"), 200, 100 },
                    { new Guid("dd1f9853-c241-4258-8059-cdf5e1432d34"), new Guid("f1992220-dfad-4d92-867f-fec102e47f0a"), 200, 100 }
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
                name: "ActionAggregate");
        }
    }
}
