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
                    { new Guid("330c8533-8390-48c4-8065-36d0322bba86"), 500, "Open Door1 Of Balcony", "Open-BalconyDoor1", 100 },
                    { new Guid("444a4901-066b-4bee-9786-2a80e565c539"), 500, "Move To Balcony Human1 Via Bedroom1", "Move-Balcony-Bedroom1", 100 },
                    { new Guid("4d49e450-ccd5-4dfc-9aec-d2c4b05a048c"), 100, "Open Window Of Balcony", "Open-BalconyWindow", 100 },
                    { new Guid("d98c2485-7ad0-4d9d-92c8-594fba0ad286"), 50, "Sit Under BalconyWindow", "Sit-BalconyWindow", 100 }
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
                    { new Guid("0f7f7af7-f0e3-43ce-a27f-762a2ace33ee"), "Stand", 75, 65, "Medium", "Normal", "Human2" },
                    { new Guid("14bb7a62-23ff-4a78-bb94-46c1ee3ea5e9"), "Stand", 10, 74, "Medium", "Tired", "Human1" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CoordinateX", "CoordinateY", "Description", "IsMovable", "MetaData", "Name", "State", "Type" },
                values: new object[,]
                {
                    { new Guid("03833720-c84f-48f3-845f-cecaa95423ef"), 51, 55, "Bedroom2 AirConditioner", false, "{\"Tempreture\":20,\"Speed\":10}", "AirConditioner2", "Off", "Electronic" },
                    { new Guid("18793e8f-eaeb-4af7-8a74-7b551fe0b350"), 35, 15, "LivingRoom Chair1", false, "", "Chair1", "NotBeUsing", "Usable" },
                    { new Guid("1a62f8b2-5698-4d67-befe-d45192160f0e"), 55, 15, "LivingRoom Lamp", false, "", "Lamp4", "Off", "Electronic" },
                    { new Guid("222b948c-cd40-49e1-b488-fca33f30ceb1"), 75, 50, "Bedroom2 Door", false, "", "Bedroom2Door", "Close", "Openable" },
                    { new Guid("337a87f7-285a-4264-af1e-dce2ae6edc05"), 25, 65, "Bedroom1 Lamp", false, "{\"Severity\":20}", "Lamp1", "Off", "Electronic" },
                    { new Guid("351357ee-47a8-4426-a79d-dc13d248af30"), 55, 30, "LivingRoom Door", false, "", "LivingRoomDoor", "Close", "Openable" },
                    { new Guid("4d22cd79-3f6c-4cf5-abd4-764b01403c09"), 90, 75, "Bedroom2 Chair", false, "", "Chair21", "NotBeUsing", "Usable" },
                    { new Guid("5194bfba-5ec7-44f3-bfce-dc69ba932d49"), 15, 30, "Kitchen Door", false, "", "KitchenDoor", "Close", "Openable" },
                    { new Guid("5545f5e3-86a4-4622-aded-e876f116b71f"), 60, 65, "Bedroom2 Bed", false, "{\"Tempreture\":20,\"Speed\":10}", "Bedroom2Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("60ee9f38-825a-446f-a4f4-721c7d75c10e"), 29, 15, "Kitchen WashingMachine", false, "", "WashingMachine", "NotBeUsing", "Usable" },
                    { new Guid("61fcc839-7b1c-41b9-ac3e-5597567cb45b"), 40, 65, "Bedroom1 Bed", false, "", "Bedroom1Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("813eaa5b-a46a-4fd7-af17-df9f1f2f2996"), 40, 15, "LivingRoom Table", false, "", "Table", "NotBeUsing", "Usable" },
                    { new Guid("892f9226-af81-427c-800a-0a47f934cd96"), 0, 65, "Bedroom1 Window", false, "", "Bedroom1Window", "Close", "Openable" },
                    { new Guid("8aaad363-add4-47e3-8b6a-9166a623df5e"), 25, 1, "Kitchen DishWasher", false, "", "DishWasher", "NotBeUsing", "Usable" },
                    { new Guid("91fcd1cb-869e-40de-a531-91765f0fd6f3"), 75, 65, "Bedroom2 Lamp", false, "{\"Severity\":20}", "Lamp2", "Off", "Electronic" },
                    { new Guid("98b4113a-cc22-4b29-b7b8-c117d7fce9c0"), 50, 40, "Corridor Lamp", false, "", "Lamp7", "Off", "Electronic" },
                    { new Guid("9e0c6f82-f310-4134-9a8f-c171fcc4b61c"), 40, 29, "LivingRoom AirConditioner", false, "{\"Tempreture\":20,\"Speed\":10}", "AirConditioner3", "Off", "Electronic" },
                    { new Guid("a2d5210e-cfe1-4453-89d4-cb748ed85c68"), 49, 55, "Bedroom1 AirConditioner", false, "", "AirConditioner1", "Off", "Electronic" },
                    { new Guid("a4b0edd0-c007-4d16-a67e-64882197971a"), 15, 1, "Kitchen Oven", false, "", "Oven", "NotBeUsing", "Usable" },
                    { new Guid("a69fd101-15b1-4561-a618-fcdb3cd4c2e6"), 1, 15, "Kitchen Refrigerator", false, "", "Refrigerator", "Close", "Openable" },
                    { new Guid("b2184ad9-0644-4d8a-bf6d-8a245e650c8e"), 45, 15, "LivingRoom Chair2", false, "", "Chair2", "NotBeUsing", "Usable" },
                    { new Guid("b516ff6a-bae6-453b-9e44-347e45423b4c"), 25, 80, "Balcony Door1", false, "", "BalconyDoor1", "Close", "Openable" },
                    { new Guid("bd6b3d7b-5842-48fd-8746-f75b82d468a1"), 40, 20, "LivingRoom Chair4", false, "", "Chair4", "NotBeUsing", "Usable" },
                    { new Guid("bd6be63c-d59f-4ced-b37f-f7e6d8b76949"), 50, 100, "Balcony Window", false, "", "BalconyWindow", "Close", "Openable" },
                    { new Guid("bd8555e2-3bfb-485e-9584-7d553f1fdd64"), 70, 20, "LivingRoom Sofa1", false, "{\"Capacity\":1}", "Sofa1", "NotFull", "UseWithCapacity" },
                    { new Guid("c91a2fb2-2c69-4ce3-a512-89cebd7106eb"), 55, 0, "House Door", false, "", "HouseDoor", "Close", "Openable" },
                    { new Guid("cadd09d8-79ec-4c7b-a324-695b3f2dc5c0"), 25, 50, "Bedroom1 Door", false, "", "Bedroom1Door", "Close", "Openable" },
                    { new Guid("cc0146c8-c5ba-45ff-95c9-6ddb8449fbcd"), 10, 75, "Bedroom1 Chair", false, "", "Chair11", "NotBeUsing", "Usable" },
                    { new Guid("ccb64e2b-0115-4f9b-b2b3-94e88db5d161"), 90, 79, "Bedroom2 Laptop", true, "{\"Charge\":90,\"IsInCharge\":false}", "Laptop", "Off", "Electronic" },
                    { new Guid("d5d22ce2-ed44-485a-9081-bc77897e953d"), 100, 65, "Bedroom2 Window", false, "", "Bedroom2Window", "Close", "Openable" },
                    { new Guid("d9e462fe-0561-4823-ab2b-ada3ccf797fb"), 90, 15, "Bathroom Lamp", false, "", "Lamp5", "Off", "Electronic" },
                    { new Guid("db0f80a5-209a-404a-b4cf-2e1a91f5b647"), 10, 79, "Bedroom1 Computer", false, "", "Computer", "Off", "Electronic" },
                    { new Guid("e0f48fe6-c700-4aa1-8d84-800c75fa715a"), 60, 15, "LivingRoom Sofa3", false, "{\"Capacity\":3}", "Sofa3", "NotFull", "UseWithCapacity" },
                    { new Guid("e91fdf09-2ef3-4c0b-8025-452b4846a4eb"), 50, 90, "Balcony Lamp", false, "", "Lamp6", "Off", "Electronic" },
                    { new Guid("eab071be-e981-4b59-ad88-db19f5fb5488"), 75, 80, "Balcony Door2", false, "", "BalconyDoor2", "Close", "Openable" },
                    { new Guid("ec87577d-82ac-466c-8be8-5f8469db4dca"), 90, 30, "Bathroom Door", false, "", "BathroomDoor", "Close", "Openable" },
                    { new Guid("eca535f8-09bc-4e26-84f6-c3c06099e235"), 70, 10, "LivingRoom Sofa2", false, "{\"Capacity\":2}", "Sofa2", "NotFull", "UseWithCapacity" },
                    { new Guid("f59f3682-5f46-4940-9153-b2664700d56b"), 40, 10, "LivingRoom Chair3", false, "", "Chair3", "NotBeUsing", "Usable" },
                    { new Guid("f985353a-d9a6-4e54-af72-42cce33e4c93"), 79, 15, "LivingRoom TV", false, "{\"Channel\":1,\"Sound\":20}", "TV", "Off", "Electronic" },
                    { new Guid("fec6eaf3-807a-45e5-b7a7-1f8ae0898e3c"), 15, 15, "Kitchen Lamp", false, "", "Lamp3", "Off", "Electronic" }
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
                    { new Guid("07c40895-7579-4948-b46a-2dfd98fe5c0b"), new Guid("444a4901-066b-4bee-9786-2a80e565c539"), "Human1", "Bedroom1", "IsIn", "HumanPosition" },
                    { new Guid("0ae606cd-6ee2-4c69-b8ba-e18a7ad23e72"), new Guid("444a4901-066b-4bee-9786-2a80e565c539"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("2f25a3f3-4bf5-49dd-afe7-33730d456641"), new Guid("d98c2485-7ad0-4d9d-92c8-594fba0ad286"), "Human1", "Sit", "StateIsNot", "HumanBodyStatus" },
                    { new Guid("33fa3e5b-1fc3-45fc-a21b-b97fdbbf878b"), new Guid("d98c2485-7ad0-4d9d-92c8-594fba0ad286"), "BalconyWindow", "Open", "StateIs", "ItemState" },
                    { new Guid("3c296e51-3209-4f0c-b76e-d2358a1d1fd4"), new Guid("444a4901-066b-4bee-9786-2a80e565c539"), "BalconyDoor1", "Open", "StateIs", "ItemState" },
                    { new Guid("46d52c1a-5977-43ee-891d-52613868335a"), new Guid("330c8533-8390-48c4-8065-36d0322bba86"), "Human1", "Bedroom1", "IsIn", "HumanPosition" },
                    { new Guid("5fdbfae9-aa23-43c9-bf13-6dbbd921df06"), new Guid("330c8533-8390-48c4-8065-36d0322bba86"), "BalconyDoor1", "Close", "StateIs", "ItemState" },
                    { new Guid("8528c930-e8b5-4f7f-a70f-6bfa8c295201"), new Guid("4d49e450-ccd5-4dfc-9aec-d2c4b05a048c"), "Human1", "Balcony", "IsIn", "HumanPosition" },
                    { new Guid("8dd870f8-799c-47a0-aaac-037e92d7cdfa"), new Guid("4d49e450-ccd5-4dfc-9aec-d2c4b05a048c"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("c7c455a3-4b50-40a2-b87f-bf1c8203c129"), new Guid("d98c2485-7ad0-4d9d-92c8-594fba0ad286"), "Human1", "Tired", "StateIs", "MentalStatus" },
                    { new Guid("d798ab23-7fbb-4d7f-8f16-ca28abf5b020"), new Guid("d98c2485-7ad0-4d9d-92c8-594fba0ad286"), "Human1", "Balcony", "IsIn", "HumanPosition" },
                    { new Guid("ded7721a-c61c-4481-b841-a0ef35db4a03"), new Guid("330c8533-8390-48c4-8065-36d0322bba86"), "Human1", "Stand", "StateIs", "HumanBodyStatus" }
                });

            migrationBuilder.InsertData(
                table: "ActionResult",
                columns: new[] { "Id", "ActionAggregateId", "CaseStudy", "ResultCaseChange", "ResultCaseType", "ResultType" },
                values: new object[,]
                {
                    { new Guid("03fff1c9-cd4a-4337-810c-8510a6218dc7"), new Guid("d98c2485-7ad0-4d9d-92c8-594fba0ad286"), "Human1", "Normal", "State", "MentalStatus" },
                    { new Guid("0c9a02f5-7998-44e0-9e96-93ead303633b"), new Guid("444a4901-066b-4bee-9786-2a80e565c539"), "Human1", "25-81", "Position", "HumanPosition" },
                    { new Guid("1813d626-b256-4de1-8d99-e2d3fae7d5be"), new Guid("4d49e450-ccd5-4dfc-9aec-d2c4b05a048c"), "BalconyWindow", "Open", "State", "ItemState" },
                    { new Guid("4283e834-68e0-432a-89e6-a71ac030e38b"), new Guid("d98c2485-7ad0-4d9d-92c8-594fba0ad286"), "Human1", "Sit", "State", "HumanBodyStatus" },
                    { new Guid("60510682-565c-4a79-952a-609c4827567b"), new Guid("4d49e450-ccd5-4dfc-9aec-d2c4b05a048c"), "Human1", "50-99", "Position", "HumanPosition" },
                    { new Guid("6a316ec5-a09f-4628-a4e9-bdcb93d200b7"), new Guid("4d49e450-ccd5-4dfc-9aec-d2c4b05a048c"), "Light", "20-IF:Day", "Increase", "Environment" },
                    { new Guid("f804eb21-3a1d-46eb-96c6-d769a1d86508"), new Guid("330c8533-8390-48c4-8065-36d0322bba86"), "Human1", "25-79", "Position", "HumanPosition" }
                });

            migrationBuilder.InsertData(
                table: "NextAction",
                columns: new[] { "Id", "ActionAggregateId", "Delay", "Possibility" },
                values: new object[,]
                {
                    { new Guid("444a4901-066b-4bee-9786-2a80e565c539"), new Guid("330c8533-8390-48c4-8065-36d0322bba86"), 200, 100 },
                    { new Guid("4d49e450-ccd5-4dfc-9aec-d2c4b05a048c"), new Guid("444a4901-066b-4bee-9786-2a80e565c539"), 200, 100 },
                    { new Guid("d98c2485-7ad0-4d9d-92c8-594fba0ad286"), new Guid("4d49e450-ccd5-4dfc-9aec-d2c4b05a048c"), 100, 100 }
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
