﻿using System;
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
                columns: new[] { "Id", "Delay", "Description", "EndPossibility", "Name" },
                values: new object[,]
                {
                    { new Guid("003a236e-f004-4de3-9830-20c1db8b1764"), 1500, "Open Door Of Bedroom2", 100, "Open-Bedroom2Door" },
                    { new Guid("013e9e85-252c-45b7-a29b-61341fa067a7"), 800, "Sit On Sofa1", 100, "Sit-Sofa1" },
                    { new Guid("0a4eab14-8f2c-4200-b7df-ced56ba78703"), 200, "Decrease Degree Of AirConditioner3", 100, "Decrease-Degree" },
                    { new Guid("20427652-3acf-4d07-b6c0-908c62193f29"), 350, "Decrease Sound Of TV", 100, "Decrease-Sound" },
                    { new Guid("675e2234-99ff-4523-ac6c-ce7fca809d24"), 500, "Move To Balcony Human1 Via Bedroom1", 100, "Move-Balcony-Bedroom1" },
                    { new Guid("7797c8f4-ef17-4348-8bc8-800b9cd0ea53"), 600, "Turn On AirConditioner3", 100, "On-AirConditioner3" },
                    { new Guid("78a6a523-6b28-4594-9d84-1a84a9ff3774"), 200, "Turn On TV", 50, "On-TV" },
                    { new Guid("93b04c8c-1122-422b-82a4-0d1798c6732d"), 200, "Human2 Stand In LivingRoom", 100, "Stand-LivingRoom" },
                    { new Guid("95fd3b09-81ef-4f9c-8e0d-823ecb964384"), 500, "Open Door1 Of Balcony", 100, "Open-BalconyDoor1" },
                    { new Guid("b5f15224-fc7e-4352-8973-23c95b301b20"), 50, "Sit Under BalconyWindow", 100, "Sit-BalconyWindow" },
                    { new Guid("d6c69a72-5f8c-4b32-886c-c4206a4797af"), 400, "Open Window Of Balcony", 100, "Open-LivinRoomDoor" },
                    { new Guid("d90f0f77-7467-4214-8339-4c022c65f49e"), 500, "Move To Corridor Human2 Via Bedroom2", 100, "Move-Corridor-Bedroom1" },
                    { new Guid("e1ace7d4-b3c0-4513-8c0a-9481247eed96"), 350, "Increase Sound Of TV", 100, "Increase-Sound" },
                    { new Guid("e7964d43-29b9-4659-858f-a4706aed921f"), 100, "Open Window Of Balcony", 100, "Open-BalconyWindow" },
                    { new Guid("fc99b7d5-8d77-41ad-9109-20cec4e36b05"), 100, "Move To LivingRoom Human2 Via Corridor", 100, "Move-LivingRoom-Corridor" }
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
                    { new Guid("00d59ac1-7e4a-4830-9e4e-2dcc3a1e596e"), "Stand", 75, 65, "Medium", "Bored", "Human2" },
                    { new Guid("c1195a34-25be-4812-afc9-fae216c88a3c"), "Stand", 10, 74, "Medium", "Tired", "Human1" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CoordinateX", "CoordinateY", "Description", "IsMovable", "MetaData", "Name", "State", "Type" },
                values: new object[,]
                {
                    { new Guid("024d8641-5d91-4fbf-a1c1-1ca108e0d438"), 25, 65, "Bedroom1 Lamp", false, "{\"Severity\":20}", "Lamp1", "Off", "Electronic" },
                    { new Guid("03f78676-eb01-4d50-ae5a-018a0fc81249"), 1, 15, "Kitchen Refrigerator", false, "", "Refrigerator", "Close", "Openable" },
                    { new Guid("0762cfa0-bada-4239-a605-da067cef66c1"), 90, 75, "Bedroom2 Chair", false, "", "Chair21", "NotBeUsing", "Usable" },
                    { new Guid("0c52c659-ea3e-44da-a82a-974bf187b341"), 15, 30, "Kitchen Door", false, "", "KitchenDoor", "Close", "Openable" },
                    { new Guid("128f9298-1865-43b4-b5a2-824a9ad7cb7c"), 0, 65, "Bedroom1 Window", false, "", "Bedroom1Window", "Close", "Openable" },
                    { new Guid("19e0bcb8-1e2a-4094-860e-4c30e3ab6986"), 25, 1, "Kitchen DishWasher", false, "", "DishWasher", "NotBeUsing", "Usable" },
                    { new Guid("1b9d1533-4e49-4868-b3ae-81fa4bd5371f"), 29, 15, "Kitchen WashingMachine", false, "", "WashingMachine", "NotBeUsing", "Usable" },
                    { new Guid("1ca65fda-9b45-4838-abec-be64a123d0cb"), 60, 15, "LivingRoom Sofa3", false, "{\"Capacity\":3}", "Sofa3", "NotFull", "UseWithCapacity" },
                    { new Guid("1e3284a8-65b5-425c-8aae-da244372ef23"), 75, 80, "Balcony Door2", false, "", "BalconyDoor2", "Close", "Openable" },
                    { new Guid("1e7c6010-3c16-4914-8c7a-2401546d27b1"), 40, 15, "LivingRoom Table", false, "", "Table", "NotBeUsing", "Usable" },
                    { new Guid("212928f8-22c6-4790-9bd0-3f5ad3e24b47"), 45, 15, "LivingRoom Chair2", false, "", "Chair2", "NotBeUsing", "Usable" },
                    { new Guid("24958e4f-dfdd-42ca-9720-4a26ce200619"), 50, 40, "Corridor Lamp", false, "", "Lamp7", "Off", "Electronic" },
                    { new Guid("29cbaf02-08f6-4831-bb1b-ffbe34fb7f7a"), 50, 90, "Balcony Lamp", false, "", "Lamp6", "Off", "Electronic" },
                    { new Guid("327ff301-7105-4577-a3fb-7d577ae5f506"), 40, 20, "LivingRoom Chair4", false, "", "Chair4", "NotBeUsing", "Usable" },
                    { new Guid("49a59a57-3aff-4396-91be-bd522fa9d55c"), 79, 15, "LivingRoom TV", false, "{\"Channel\":1,\"Sound\":60}", "TV", "Off", "Electronic" },
                    { new Guid("5131ac27-8097-4351-91c4-f6a9e2f62200"), 25, 50, "Bedroom1 Door", false, "", "Bedroom1Door", "Close", "Openable" },
                    { new Guid("52036351-0d33-4223-be8c-8456dc252eff"), 75, 50, "Bedroom2 Door", false, "", "Bedroom2Door", "Close", "Openable" },
                    { new Guid("56d59d9e-9e7b-4c80-829a-15965bb9c0f4"), 60, 65, "Bedroom2 Bed", false, "{\"Temperature\":20,\"Speed\":10}", "Bedroom2Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("5b0b8856-a249-428e-a46e-5c9ea79417a6"), 50, 100, "Balcony Window", false, "", "BalconyWindow", "Close", "Openable" },
                    { new Guid("5bd76d3b-873f-4217-bc61-72354fe2749c"), 10, 75, "Bedroom1 Chair", false, "", "Chair11", "NotBeUsing", "Usable" },
                    { new Guid("6bb58731-6ee8-4db3-9451-217aa29a1f82"), 35, 15, "LivingRoom Chair1", false, "", "Chair1", "NotBeUsing", "Usable" },
                    { new Guid("7331f40b-ba5c-4b68-ab55-6b85b46b50fb"), 15, 1, "Kitchen Oven", false, "", "Oven", "NotBeUsing", "Usable" },
                    { new Guid("7ed22334-0c43-4bf0-b26c-cfda8ae38365"), 75, 65, "Bedroom2 Lamp", false, "{\"Severity\":20}", "Lamp2", "Off", "Electronic" },
                    { new Guid("937c21b4-b0b0-4224-b7e1-a6695ae0a535"), 10, 79, "Bedroom1 Computer", false, "", "Computer", "Off", "Electronic" },
                    { new Guid("95635073-cd66-4396-bc13-80d22594d98b"), 70, 20, "LivingRoom Sofa1", false, "{\"Capacity\":1}", "Sofa1", "NotFull", "UseWithCapacity" },
                    { new Guid("95b2ef84-ba1d-412a-88d0-13f67cfaeee1"), 25, 80, "Balcony Door1", false, "", "BalconyDoor1", "Close", "Openable" },
                    { new Guid("95c3ba9e-4936-47e0-b40e-1b3de667ee0d"), 49, 55, "Bedroom1 AirConditioner", false, "", "AirConditioner1", "Off", "Electronic" },
                    { new Guid("99259c4d-2a3c-4c32-b5c1-07e9135f3004"), 51, 55, "Bedroom2 AirConditioner", false, "{\"Temperature\":20,\"Speed\":10}", "AirConditioner2", "Off", "Electronic" },
                    { new Guid("99c7078b-8d52-4581-a30c-e5f34a951ded"), 55, 15, "LivingRoom Lamp", false, "", "Lamp4", "Off", "Electronic" },
                    { new Guid("9bc81b90-f2da-4e30-a178-4f522a522811"), 55, 0, "House Door", false, "", "HouseDoor", "Close", "Openable" },
                    { new Guid("a2c9844b-5170-4ad3-a272-b473e765dd6b"), 40, 65, "Bedroom1 Bed", false, "", "Bedroom1Bed", "NotFull", "UseWithCapacity" },
                    { new Guid("a6e44d1d-2eb8-4145-b7f1-1bcaad237d4e"), 90, 30, "Bathroom Door", false, "", "BathroomDoor", "Close", "Openable" },
                    { new Guid("ab411793-053e-421e-9a7b-2f9880cb8232"), 90, 79, "Bedroom2 Laptop", true, "{\"Charge\":90,\"IsInCharge\":false}", "Laptop", "Off", "Electronic" },
                    { new Guid("b0df23f5-5f34-4a79-8ad3-842babdc33d5"), 40, 10, "LivingRoom Chair3", false, "", "Chair3", "NotBeUsing", "Usable" },
                    { new Guid("ba651765-7925-43a2-b681-ed342a37b28f"), 70, 10, "LivingRoom Sofa2", false, "{\"Capacity\":2}", "Sofa2", "NotFull", "UseWithCapacity" },
                    { new Guid("c04055e1-921c-45e9-8ac5-af4add712fe4"), 40, 29, "LivingRoom AirConditioner", false, "{\"Temperature\":20,\"Speed\":10}", "AirConditioner3", "Off", "Electronic" },
                    { new Guid("cbd23f24-0e72-4aec-a6cb-7f8a4a5f9b80"), 55, 30, "LivingRoom Door", false, "", "LivingRoomDoor", "Close", "Openable" },
                    { new Guid("d4935459-eacd-4749-8707-2117b3b6dd8b"), 100, 65, "Bedroom2 Window", false, "", "Bedroom2Window", "Close", "Openable" },
                    { new Guid("dcbc7ea5-23e4-422b-a1e7-6c86db986f84"), 90, 15, "Bathroom Lamp", false, "", "Lamp5", "Off", "Electronic" },
                    { new Guid("fbcb276f-f3f5-4f07-b718-d0cd94c7baf9"), 15, 15, "Kitchen Lamp", false, "", "Lamp3", "Off", "Electronic" }
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
                    { new Guid("0237922f-9aca-4334-9968-20ffb9d10c51"), new Guid("20427652-3acf-4d07-b6c0-908c62193f29"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("09ca63e0-debf-4b99-9e07-66effea7e949"), new Guid("0a4eab14-8f2c-4200-b7df-ced56ba78703"), "AirConditioner3", "On", "StateIs", "ItemState" },
                    { new Guid("0b3db622-164c-4bd0-9350-05cd045d215c"), new Guid("78a6a523-6b28-4594-9d84-1a84a9ff3774"), "TV", "Off", "StateIs", "ItemState" },
                    { new Guid("108b9820-1353-45fd-bd0b-6a8da701bfaf"), new Guid("013e9e85-252c-45b7-a29b-61341fa067a7"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("1644310f-41db-473b-bc2a-5063e5f5968e"), new Guid("fc99b7d5-8d77-41ad-9109-20cec4e36b05"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("1cbb7ccb-8aa3-41ba-9ff9-ac37e38f3b7e"), new Guid("e1ace7d4-b3c0-4513-8c0a-9481247eed96"), "TV", "On", "StateIs", "ItemState" },
                    { new Guid("20db01ec-8200-4698-84ef-f77aa05cccb0"), new Guid("95fd3b09-81ef-4f9c-8e0d-823ecb964384"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("26d49566-78bd-486a-b6fd-03dac9c295f0"), new Guid("d90f0f77-7467-4214-8339-4c022c65f49e"), "Bedroom2Door", "Open", "StateIs", "ItemState" },
                    { new Guid("2ead71ea-e218-4c28-be1e-6756a95bcbe9"), new Guid("003a236e-f004-4de3-9830-20c1db8b1764"), "Bedroom1Door", "Close", "StateIs", "ItemState" },
                    { new Guid("35e9bdb2-53c7-4e53-91f4-93af496d7438"), new Guid("0a4eab14-8f2c-4200-b7df-ced56ba78703"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("371eab5e-cf8a-4780-aa24-a61c42d6d05e"), new Guid("e1ace7d4-b3c0-4513-8c0a-9481247eed96"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("3bef1f7c-6631-4487-8561-2dc01153b273"), new Guid("e7964d43-29b9-4659-858f-a4706aed921f"), "Human1", "Balcony", "IsIn", "HumanPosition" },
                    { new Guid("3e0cf3c6-5cdd-443b-a5b4-c8cee30f4b4c"), new Guid("0a4eab14-8f2c-4200-b7df-ced56ba78703"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("3eac040c-44a9-4ada-9f7a-96818b105c32"), new Guid("7797c8f4-ef17-4348-8bc8-800b9cd0ea53"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("46a8e9a7-135c-43ce-acbb-75d62d36c72b"), new Guid("78a6a523-6b28-4594-9d84-1a84a9ff3774"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("47db513e-2125-4926-9e6b-1a6ab7ff9ccf"), new Guid("e1ace7d4-b3c0-4513-8c0a-9481247eed96"), "Human2", "Sit", "StateIs", "HumanBodyStatus" },
                    { new Guid("51801131-2a45-4993-b52d-790157053afa"), new Guid("20427652-3acf-4d07-b6c0-908c62193f29"), "TV", "On", "StateIs", "ItemState" },
                    { new Guid("5407414b-135c-4443-b895-e9637580ff67"), new Guid("b5f15224-fc7e-4352-8973-23c95b301b20"), "Human1", "Sit", "StateIsNot", "HumanBodyStatus" },
                    { new Guid("5fa9f41d-41f6-431a-b9d1-217e780f588e"), new Guid("95fd3b09-81ef-4f9c-8e0d-823ecb964384"), "BalconyDoor1", "Close", "StateIs", "ItemState" },
                    { new Guid("67a51c53-e70c-4631-b5b9-895b8c88a423"), new Guid("003a236e-f004-4de3-9830-20c1db8b1764"), "Human2", "Bedroom2", "IsIn", "HumanPosition" },
                    { new Guid("7e3488a1-b23a-4637-8096-e7b8778ed746"), new Guid("d6c69a72-5f8c-4b32-886c-c4206a4797af"), "LivingRoomDoor", "Close", "StateIs", "ItemState" },
                    { new Guid("7f64d09a-1888-44b8-ab7e-e53060abdee7"), new Guid("b5f15224-fc7e-4352-8973-23c95b301b20"), "Human1", "Tired", "StateIs", "MentalStatus" },
                    { new Guid("86599e09-f1aa-47b0-a6da-3caac4da6425"), new Guid("675e2234-99ff-4523-ac6c-ce7fca809d24"), "BalconyDoor1", "Open", "StateIs", "ItemState" },
                    { new Guid("9b09c352-8b57-447a-a324-10ec457e39c7"), new Guid("fc99b7d5-8d77-41ad-9109-20cec4e36b05"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("9b549321-258c-4002-aa70-f9e6d02596fb"), new Guid("d6c69a72-5f8c-4b32-886c-c4206a4797af"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("9cb6abb0-6cee-491c-8f29-2b7cf7909213"), new Guid("78a6a523-6b28-4594-9d84-1a84a9ff3774"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("a45945b7-59b6-442b-a6a9-780d241f18b9"), new Guid("e7964d43-29b9-4659-858f-a4706aed921f"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("b5bfa11f-60fc-4207-b9a3-c9b2b1e985b3"), new Guid("20427652-3acf-4d07-b6c0-908c62193f29"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("b8af651e-8ea7-4cce-8fa3-faea439a5993"), new Guid("b5f15224-fc7e-4352-8973-23c95b301b20"), "Human1", "Balcony", "IsIn", "HumanPosition" },
                    { new Guid("b9c48a70-5371-42ef-834f-31cc0f3267ac"), new Guid("003a236e-f004-4de3-9830-20c1db8b1764"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("ba410b07-67f2-45f0-adb1-7dd6b5f14ed6"), new Guid("fc99b7d5-8d77-41ad-9109-20cec4e36b05"), "LivingRoomDoor", "Open", "StateIs", "ItemState" },
                    { new Guid("bb590efc-36a8-4838-870b-9bb0990789e9"), new Guid("7797c8f4-ef17-4348-8bc8-800b9cd0ea53"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("c5dcfded-70fa-43e3-afc3-bd2a1bde04ab"), new Guid("93b04c8c-1122-422b-82a4-0d1798c6732d"), "Human2", "Stand", "StateIsNot", "HumanBodyStatus" },
                    { new Guid("c7d3d793-57f4-4879-9b60-b57fb7dbde17"), new Guid("d6c69a72-5f8c-4b32-886c-c4206a4797af"), "Human2", "Corridor", "IsIn", "HumanPosition" },
                    { new Guid("d510c139-67be-4bf6-ab45-aa5bf5cc3e05"), new Guid("675e2234-99ff-4523-ac6c-ce7fca809d24"), "Human1", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("da0258a3-937a-4435-8437-5c48d1ac7de2"), new Guid("d90f0f77-7467-4214-8339-4c022c65f49e"), "Human2", "Stand", "StateIs", "HumanBodyStatus" },
                    { new Guid("e5c90d5a-0bba-4006-8a28-0662759d5793"), new Guid("93b04c8c-1122-422b-82a4-0d1798c6732d"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("e6ebc300-a005-4727-bbb8-53a055d474bb"), new Guid("675e2234-99ff-4523-ac6c-ce7fca809d24"), "Human1", "Bedroom1", "IsIn", "HumanPosition" },
                    { new Guid("e7630d88-c374-4889-9b21-73824bffcd89"), new Guid("013e9e85-252c-45b7-a29b-61341fa067a7"), "Human2", "LivingRoom", "IsIn", "HumanPosition" },
                    { new Guid("ea103a9c-6af3-4a2d-8a65-7bcfa069ab79"), new Guid("95fd3b09-81ef-4f9c-8e0d-823ecb964384"), "Human1", "Bedroom1", "IsIn", "HumanPosition" },
                    { new Guid("ef980864-b6c1-4b4b-897f-ae9a7f74b0e6"), new Guid("d90f0f77-7467-4214-8339-4c022c65f49e"), "Human2", "Bedroom2", "IsIn", "HumanPosition" },
                    { new Guid("f8e89998-d320-49b7-b831-f96357d85ded"), new Guid("b5f15224-fc7e-4352-8973-23c95b301b20"), "BalconyWindow", "Open", "StateIs", "ItemState" }
                });

            migrationBuilder.InsertData(
                table: "ActionResult",
                columns: new[] { "Id", "ActionAggregateId", "CaseStudy", "ResultCaseChange", "ResultCaseType", "ResultType" },
                values: new object[,]
                {
                    { new Guid("0f135dc1-8e81-41f2-9334-fbf8a7ffc2fc"), new Guid("e1ace7d4-b3c0-4513-8c0a-9481247eed96"), "Sound", "10-40", "Increase", "Environment" },
                    { new Guid("1b350d6a-2927-47dd-9051-596c6bc266c5"), new Guid("d6c69a72-5f8c-4b32-886c-c4206a4797af"), "LivingRoomDoor", "Open", "State", "ItemState" },
                    { new Guid("1d491af8-3a96-4d86-848b-7606a05eaa27"), new Guid("fc99b7d5-8d77-41ad-9109-20cec4e36b05"), "Human2", "55-29", "Position", "HumanPosition" },
                    { new Guid("253ee7bc-cf7b-4df6-a4d9-0c35440faa9c"), new Guid("e7964d43-29b9-4659-858f-a4706aed921f"), "Human1", "50-99", "Position", "HumanPosition" },
                    { new Guid("28fdf1a0-8a6a-4ca0-977d-ff15ed994241"), new Guid("e7964d43-29b9-4659-858f-a4706aed921f"), "BalconyWindow", "Open", "State", "ItemState" },
                    { new Guid("2902d1c5-07fe-4415-813a-d8b86006be83"), new Guid("b5f15224-fc7e-4352-8973-23c95b301b20"), "Human1", "Normal", "State", "MentalStatus" },
                    { new Guid("2d7445cc-9a55-467c-9b63-327583d5251f"), new Guid("95fd3b09-81ef-4f9c-8e0d-823ecb964384"), "BalconyDoor1", "Open", "State", "ItemState" },
                    { new Guid("3d1e9e36-b311-4878-91c8-7a3c0565941d"), new Guid("e1ace7d4-b3c0-4513-8c0a-9481247eed96"), "Light", "10", "Increase", "Environment" },
                    { new Guid("3fdbad18-d691-4b1f-aac5-b57d4c52e06f"), new Guid("0a4eab14-8f2c-4200-b7df-ced56ba78703"), "Degree", "7", "Decrease", "Environment" },
                    { new Guid("4023be7a-ac71-4ab6-ac7f-647f6c45f0a3"), new Guid("95fd3b09-81ef-4f9c-8e0d-823ecb964384"), "Human1", "25-79", "Position", "HumanPosition" },
                    { new Guid("43d35959-a696-4842-b62c-18a4b5b3c93b"), new Guid("d6c69a72-5f8c-4b32-886c-c4206a4797af"), "Human2", "55-31", "Position", "HumanPosition" },
                    { new Guid("44bb12e4-2b62-4751-a7cd-ea6a5a1ba627"), new Guid("d90f0f77-7467-4214-8339-4c022c65f49e"), "Human2", "75-49", "Position", "HumanPosition" },
                    { new Guid("46edf67d-a77f-431f-9859-7b8ff372277f"), new Guid("675e2234-99ff-4523-ac6c-ce7fca809d24"), "Human1", "25-81", "Position", "HumanPosition" },
                    { new Guid("4b67e2fc-3970-40e8-a33b-311a1770c9cd"), new Guid("7797c8f4-ef17-4348-8bc8-800b9cd0ea53"), "AirConditioner3", "On", "State", "ItemState" },
                    { new Guid("574ebb36-6a07-4587-9c4d-733bf5baa8ce"), new Guid("003a236e-f004-4de3-9830-20c1db8b1764"), "Bedroom2Door", "Open", "State", "ItemState" },
                    { new Guid("5fc785c5-158d-402b-8e45-3c702cd96c34"), new Guid("e1ace7d4-b3c0-4513-8c0a-9481247eed96"), "TV-Sound", "10-40", "Increase", "ItemMetaData" },
                    { new Guid("61599d14-32d5-4c89-9cb1-796de8dffaa8"), new Guid("20427652-3acf-4d07-b6c0-908c62193f29"), "TV-Sound", "10-40", "Decrease", "ItemMetaData" },
                    { new Guid("6606053f-ae76-4fc4-b60d-ed9c48c21aaf"), new Guid("20427652-3acf-4d07-b6c0-908c62193f29"), "Light", "10", "Increase", "Environment" },
                    { new Guid("6abdafac-5001-4d17-ac3b-d7bc38bc94fd"), new Guid("e7964d43-29b9-4659-858f-a4706aed921f"), "Light", "20-IF:Day", "Increase", "Environment" },
                    { new Guid("8a670410-b138-4b84-8b22-4ad747edfb48"), new Guid("0a4eab14-8f2c-4200-b7df-ced56ba78703"), "AirConditioner3-Temperature", "5-15", "Decrease", "ItemMetaData" },
                    { new Guid("9975bcfa-4387-4d6c-9a74-baca5be13c04"), new Guid("7797c8f4-ef17-4348-8bc8-800b9cd0ea53"), "Human2", "40-28", "Position", "HumanPosition" },
                    { new Guid("9abc0854-2928-4656-9b7d-50cdd646ba3a"), new Guid("013e9e85-252c-45b7-a29b-61341fa067a7"), "Human2", "Sit", "State", "HumanBodyStatus" },
                    { new Guid("9ce6da60-febf-430e-838d-70fb63386d4b"), new Guid("013e9e85-252c-45b7-a29b-61341fa067a7"), "Sofa1", "Full", "State", "ItemState" },
                    { new Guid("9eae5549-bde5-4148-bebc-857ecb1773b6"), new Guid("0a4eab14-8f2c-4200-b7df-ced56ba78703"), "Human2", "Cold", "State", "HumanFeelToDegree" },
                    { new Guid("a0125b20-1128-4742-99b9-651f75e644ff"), new Guid("78a6a523-6b28-4594-9d84-1a84a9ff3774"), "TV", "On", "State", "ItemState" },
                    { new Guid("b28f6f40-8e28-4db2-a1d0-e2557c81c9d3"), new Guid("b5f15224-fc7e-4352-8973-23c95b301b20"), "Human1", "Sit", "State", "HumanBodyStatus" },
                    { new Guid("d4160128-c6b4-4c85-a24d-85a6eb804953"), new Guid("20427652-3acf-4d07-b6c0-908c62193f29"), "Sound", "10-40", "Decrease", "Environment" },
                    { new Guid("ee520593-2303-41ea-87ba-16124ff2ba26"), new Guid("013e9e85-252c-45b7-a29b-61341fa067a7"), "Human2", "70-20", "Position", "HumanPosition" },
                    { new Guid("f8853ad9-6316-40b6-b0fa-c8c14922bef8"), new Guid("93b04c8c-1122-422b-82a4-0d1798c6732d"), "Human2", "Stand", "State", "HumanBodyStatus" },
                    { new Guid("fb57372f-6d09-42ec-952a-04c290b1060f"), new Guid("003a236e-f004-4de3-9830-20c1db8b1764"), "Human1", "75-51", "Position", "HumanPosition" },
                    { new Guid("fd736a35-55eb-4383-8f2c-85af94cf2f3f"), new Guid("78a6a523-6b28-4594-9d84-1a84a9ff3774"), "Human2", "Normal", "State", "MentalStatus" }
                });

            migrationBuilder.InsertData(
                table: "NextAction",
                columns: new[] { "ActionAggregateId", "Id", "Delay", "Possibility" },
                values: new object[,]
                {
                    { new Guid("7797c8f4-ef17-4348-8bc8-800b9cd0ea53"), new Guid("013e9e85-252c-45b7-a29b-61341fa067a7"), 200, 90 },
                    { new Guid("fc99b7d5-8d77-41ad-9109-20cec4e36b05"), new Guid("013e9e85-252c-45b7-a29b-61341fa067a7"), 200, 30 },
                    { new Guid("7797c8f4-ef17-4348-8bc8-800b9cd0ea53"), new Guid("0a4eab14-8f2c-4200-b7df-ced56ba78703"), 200, 10 },
                    { new Guid("78a6a523-6b28-4594-9d84-1a84a9ff3774"), new Guid("20427652-3acf-4d07-b6c0-908c62193f29"), 200, 100 },
                    { new Guid("95fd3b09-81ef-4f9c-8e0d-823ecb964384"), new Guid("675e2234-99ff-4523-ac6c-ce7fca809d24"), 200, 100 },
                    { new Guid("93b04c8c-1122-422b-82a4-0d1798c6732d"), new Guid("7797c8f4-ef17-4348-8bc8-800b9cd0ea53"), 200, 100 },
                    { new Guid("fc99b7d5-8d77-41ad-9109-20cec4e36b05"), new Guid("7797c8f4-ef17-4348-8bc8-800b9cd0ea53"), 350, 70 },
                    { new Guid("013e9e85-252c-45b7-a29b-61341fa067a7"), new Guid("78a6a523-6b28-4594-9d84-1a84a9ff3774"), 200, 100 },
                    { new Guid("e7964d43-29b9-4659-858f-a4706aed921f"), new Guid("b5f15224-fc7e-4352-8973-23c95b301b20"), 100, 100 },
                    { new Guid("d90f0f77-7467-4214-8339-4c022c65f49e"), new Guid("d6c69a72-5f8c-4b32-886c-c4206a4797af"), 200, 100 },
                    { new Guid("003a236e-f004-4de3-9830-20c1db8b1764"), new Guid("d90f0f77-7467-4214-8339-4c022c65f49e"), 200, 100 },
                    { new Guid("78a6a523-6b28-4594-9d84-1a84a9ff3774"), new Guid("e1ace7d4-b3c0-4513-8c0a-9481247eed96"), 200, 100 },
                    { new Guid("675e2234-99ff-4523-ac6c-ce7fca809d24"), new Guid("e7964d43-29b9-4659-858f-a4706aed921f"), 200, 100 },
                    { new Guid("d6c69a72-5f8c-4b32-886c-c4206a4797af"), new Guid("fc99b7d5-8d77-41ad-9109-20cec4e36b05"), 200, 100 }
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
