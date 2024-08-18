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
                name: "ActionDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionAggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionDetail_ActionAggregate_ActionAggregateId",
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

            migrationBuilder.CreateTable(
                name: "SensorDataEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreDataId = table.Column<int>(type: "int", nullable: false),
                    PreData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorDataEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorDataEntity_ActionDetail_ActionDetailId",
                        column: x => x.ActionDetailId,
                        principalTable: "ActionDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActionAggregate",
                columns: new[] { "Id", "Delay", "Description", "EndPossibility", "Name" },
                values: new object[,]
                {
                    { new Guid("043f163c-4e90-4647-9ed2-fab99a9b9742"), 53, "", 0, "Staircase|Going_up" },
                    { new Guid("1674c8df-7111-4e4a-8229-e6aef3545719"), 177, "", 0, "Bathroom|Cleaning" },
                    { new Guid("23a6aaa7-c6b5-405c-a67c-47f35abcea52"), 712, "", 0, "Living_room|Eating" },
                    { new Guid("2530e204-2314-46d0-985f-a20814bda9e2"), 132, "", 0, "Bedroom|Cleaning" },
                    { new Guid("334b124f-5a8b-4dd9-b1a3-d0142c934522"), 1668, "", 0, "Living_room|Watching_TV" },
                    { new Guid("3da4bd97-9e04-4605-8308-e08c39306883"), 53, "", 0, "Staircase|Going_down" },
                    { new Guid("3fd2df48-eac4-4784-9128-dcd6f73735d6"), 1147, "", 0, "Office|Watching_TV" },
                    { new Guid("43ec49e6-5004-4e49-a460-7652d8fee87e"), 90, "", 0, "Living_room|Cleaning" },
                    { new Guid("61302eb5-fc78-4209-9fb3-54acc0413756"), 95, "", 0, "Bedroom|Dressing" },
                    { new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), 9225, "", 0, "Office|Computing" },
                    { new Guid("632ffff7-1125-4cf9-9e59-4a25551aed04"), 131, "", 0, "Entrance|Entering" },
                    { new Guid("75bd83b1-57c4-4dac-8d8f-e314dc917c70"), 152, "", 0, "Office|Cleaning" },
                    { new Guid("87f6fbde-545f-4390-b920-7a06f69d842a"), 1646, "", 0, "Bedroom|Napping" },
                    { new Guid("8d7c1a5f-a6ee-4ac8-aeab-9a3e6050e925"), 222, "", 0, "Bathroom|Using_the_toilet" },
                    { new Guid("99d0b6ff-155b-421b-9078-05715b165746"), 112, "", 0, "Kitchen|Preparing" },
                    { new Guid("a043da6d-a7ee-434d-ba67-a44c115dc5b4"), 381, "", 0, "Kitchen|Washing_the_dishes" },
                    { new Guid("ac9589f7-81f8-42e7-ba06-c397d5c86907"), 147, "", 0, "Toilet|Using_the_toilet" },
                    { new Guid("b37a0c41-489d-4142-ab93-9eae45249b73"), 1738, "", 0, "Bedroom|Reading" },
                    { new Guid("c4ddedc5-1f2b-475e-98de-db5862118615"), 692, "", 0, "Kitchen|Cooking" },
                    { new Guid("c7979bf5-d148-449c-a885-9d4108f33e32"), 119, "", 0, "Kitchen|Cleaning" },
                    { new Guid("c8874440-bda5-47fb-8dcd-cf241693b600"), 1063, "", 0, "Bathroom|Showering" },
                    { new Guid("d1ed482f-ef80-4427-972c-8b21305c2ff9"), 207, "", 0, "Bathroom|Using_the_sink" },
                    { new Guid("d644ee52-4e08-47b9-92e3-dc62edf31951"), 1882, "", 0, "Living_room|Computing" },
                    { new Guid("e030a573-a73f-4c68-9378-7a09447dbb37"), 89, "", 100, "Entrance|Leaving" }
                });

            migrationBuilder.InsertData(
                table: "NextAction",
                columns: new[] { "ActionAggregateId", "Id", "Delay", "Possibility" },
                values: new object[,]
                {
                    { new Guid("334b124f-5a8b-4dd9-b1a3-d0142c934522"), new Guid("043f163c-4e90-4647-9ed2-fab99a9b9742"), 1, 88 },
                    { new Guid("632ffff7-1125-4cf9-9e59-4a25551aed04"), new Guid("043f163c-4e90-4647-9ed2-fab99a9b9742"), 1, 90 },
                    { new Guid("ac9589f7-81f8-42e7-ba06-c397d5c86907"), new Guid("043f163c-4e90-4647-9ed2-fab99a9b9742"), 1, 62 },
                    { new Guid("c7979bf5-d148-449c-a885-9d4108f33e32"), new Guid("043f163c-4e90-4647-9ed2-fab99a9b9742"), 1, 75 },
                    { new Guid("d644ee52-4e08-47b9-92e3-dc62edf31951"), new Guid("043f163c-4e90-4647-9ed2-fab99a9b9742"), 1, 93 },
                    { new Guid("8d7c1a5f-a6ee-4ac8-aeab-9a3e6050e925"), new Guid("1674c8df-7111-4e4a-8229-e6aef3545719"), 1, 12 },
                    { new Guid("d1ed482f-ef80-4427-972c-8b21305c2ff9"), new Guid("1674c8df-7111-4e4a-8229-e6aef3545719"), 1, 8 },
                    { new Guid("c4ddedc5-1f2b-475e-98de-db5862118615"), new Guid("23a6aaa7-c6b5-405c-a67c-47f35abcea52"), 1, 100 },
                    { new Guid("1674c8df-7111-4e4a-8229-e6aef3545719"), new Guid("2530e204-2314-46d0-985f-a20814bda9e2"), 1, 75 },
                    { new Guid("3da4bd97-9e04-4605-8308-e08c39306883"), new Guid("334b124f-5a8b-4dd9-b1a3-d0142c934522"), 1, 29 },
                    { new Guid("632ffff7-1125-4cf9-9e59-4a25551aed04"), new Guid("334b124f-5a8b-4dd9-b1a3-d0142c934522"), 1, 6 },
                    { new Guid("3fd2df48-eac4-4784-9128-dcd6f73735d6"), new Guid("3da4bd97-9e04-4605-8308-e08c39306883"), 1, 100 },
                    { new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), new Guid("3da4bd97-9e04-4605-8308-e08c39306883"), 1, 47 },
                    { new Guid("75bd83b1-57c4-4dac-8d8f-e314dc917c70"), new Guid("3da4bd97-9e04-4605-8308-e08c39306883"), 1, 100 },
                    { new Guid("d1ed482f-ef80-4427-972c-8b21305c2ff9"), new Guid("3da4bd97-9e04-4605-8308-e08c39306883"), 1, 44 },
                    { new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), new Guid("3fd2df48-eac4-4784-9128-dcd6f73735d6"), 1, 30 },
                    { new Guid("a043da6d-a7ee-434d-ba67-a44c115dc5b4"), new Guid("43ec49e6-5004-4e49-a460-7652d8fee87e"), 1, 100 },
                    { new Guid("87f6fbde-545f-4390-b920-7a06f69d842a"), new Guid("61302eb5-fc78-4209-9fb3-54acc0413756"), 1, 100 },
                    { new Guid("d1ed482f-ef80-4427-972c-8b21305c2ff9"), new Guid("61302eb5-fc78-4209-9fb3-54acc0413756"), 1, 39 },
                    { new Guid("043f163c-4e90-4647-9ed2-fab99a9b9742"), new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), 1, 33 },
                    { new Guid("1674c8df-7111-4e4a-8229-e6aef3545719"), new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), 1, 25 },
                    { new Guid("2530e204-2314-46d0-985f-a20814bda9e2"), new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), 1, 100 },
                    { new Guid("61302eb5-fc78-4209-9fb3-54acc0413756"), new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), 1, 46 },
                    { new Guid("8d7c1a5f-a6ee-4ac8-aeab-9a3e6050e925"), new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), 1, 77 },
                    { new Guid("d1ed482f-ef80-4427-972c-8b21305c2ff9"), new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), 1, 6 },
                    { new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), new Guid("75bd83b1-57c4-4dac-8d8f-e314dc917c70"), 1, 10 },
                    { new Guid("b37a0c41-489d-4142-ab93-9eae45249b73"), new Guid("87f6fbde-545f-4390-b920-7a06f69d842a"), 1, 100 },
                    { new Guid("043f163c-4e90-4647-9ed2-fab99a9b9742"), new Guid("8d7c1a5f-a6ee-4ac8-aeab-9a3e6050e925"), 1, 3 },
                    { new Guid("61302eb5-fc78-4209-9fb3-54acc0413756"), new Guid("8d7c1a5f-a6ee-4ac8-aeab-9a3e6050e925"), 1, 4 },
                    { new Guid("621131e1-ca10-4e6a-848a-2980569c4222"), new Guid("8d7c1a5f-a6ee-4ac8-aeab-9a3e6050e925"), 1, 13 },
                    { new Guid("d1ed482f-ef80-4427-972c-8b21305c2ff9"), new Guid("8d7c1a5f-a6ee-4ac8-aeab-9a3e6050e925"), 1, 3 },
                    { new Guid("3da4bd97-9e04-4605-8308-e08c39306883"), new Guid("99d0b6ff-155b-421b-9078-05715b165746"), 1, 33 },
                    { new Guid("23a6aaa7-c6b5-405c-a67c-47f35abcea52"), new Guid("a043da6d-a7ee-434d-ba67-a44c115dc5b4"), 1, 100 },
                    { new Guid("334b124f-5a8b-4dd9-b1a3-d0142c934522"), new Guid("ac9589f7-81f8-42e7-ba06-c397d5c86907"), 1, 12 },
                    { new Guid("43ec49e6-5004-4e49-a460-7652d8fee87e"), new Guid("ac9589f7-81f8-42e7-ba06-c397d5c86907"), 1, 16 },
                    { new Guid("632ffff7-1125-4cf9-9e59-4a25551aed04"), new Guid("ac9589f7-81f8-42e7-ba06-c397d5c86907"), 1, 5 },
                    { new Guid("c7979bf5-d148-449c-a885-9d4108f33e32"), new Guid("ac9589f7-81f8-42e7-ba06-c397d5c86907"), 1, 25 },
                    { new Guid("d644ee52-4e08-47b9-92e3-dc62edf31951"), new Guid("ac9589f7-81f8-42e7-ba06-c397d5c86907"), 1, 7 },
                    { new Guid("61302eb5-fc78-4209-9fb3-54acc0413756"), new Guid("b37a0c41-489d-4142-ab93-9eae45249b73"), 1, 50 },
                    { new Guid("99d0b6ff-155b-421b-9078-05715b165746"), new Guid("c4ddedc5-1f2b-475e-98de-db5862118615"), 1, 100 },
                    { new Guid("43ec49e6-5004-4e49-a460-7652d8fee87e"), new Guid("c7979bf5-d148-449c-a885-9d4108f33e32"), 1, 21 },
                    { new Guid("043f163c-4e90-4647-9ed2-fab99a9b9742"), new Guid("c8874440-bda5-47fb-8dcd-cf241693b600"), 1, 33 },
                    { new Guid("043f163c-4e90-4647-9ed2-fab99a9b9742"), new Guid("d1ed482f-ef80-4427-972c-8b21305c2ff9"), 1, 31 },
                    { new Guid("8d7c1a5f-a6ee-4ac8-aeab-9a3e6050e925"), new Guid("d1ed482f-ef80-4427-972c-8b21305c2ff9"), 1, 11 },
                    { new Guid("c8874440-bda5-47fb-8dcd-cf241693b600"), new Guid("d1ed482f-ef80-4427-972c-8b21305c2ff9"), 1, 100 },
                    { new Guid("43ec49e6-5004-4e49-a460-7652d8fee87e"), new Guid("d644ee52-4e08-47b9-92e3-dc62edf31951"), 1, 63 },
                    { new Guid("ac9589f7-81f8-42e7-ba06-c397d5c86907"), new Guid("d644ee52-4e08-47b9-92e3-dc62edf31951"), 1, 38 },
                    { new Guid("3da4bd97-9e04-4605-8308-e08c39306883"), new Guid("e030a573-a73f-4c68-9378-7a09447dbb37"), 1, 36 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionCondition_ActionAggregateId",
                table: "ActionCondition",
                column: "ActionAggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionDetail_ActionAggregateId",
                table: "ActionDetail",
                column: "ActionAggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionResult_ActionAggregateId",
                table: "ActionResult",
                column: "ActionAggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_NextAction_ActionAggregateId",
                table: "NextAction",
                column: "ActionAggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorDataEntity_ActionDetailId",
                table: "SensorDataEntity",
                column: "ActionDetailId");
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
                name: "SensorDataEntity");

            migrationBuilder.DropTable(
                name: "ActionDetail");

            migrationBuilder.DropTable(
                name: "ActionAggregate");
        }
    }
}
