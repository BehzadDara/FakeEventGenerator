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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { new Guid("0643e948-3429-4782-b163-20e9ea995d2d"), 1882, "", 0, "Living_room|Computing" },
                    { new Guid("09cbb4f4-b294-4e31-98e0-4937c829352a"), 131, "", 0, "Entrance|Entering" },
                    { new Guid("0c536f44-97c8-4188-a575-b840ca17f2d3"), 89, "", 100, "Entrance|Leaving" },
                    { new Guid("0f2f7417-6e6f-4d56-8dec-a0a9dd918154"), 147, "", 0, "Toilet|Using_the_toilet" },
                    { new Guid("24f6ae4b-6f99-4e54-865e-748e8297a25c"), 207, "", 0, "Bathroom|Using_the_sink" },
                    { new Guid("25deeb4d-2fc1-4a21-9ab5-8cda61cb3eef"), 112, "", 0, "Kitchen|Preparing" },
                    { new Guid("2c575e89-f134-420f-a5b4-a3c665adc741"), 692, "", 0, "Kitchen|Cooking" },
                    { new Guid("3184275d-3c14-408c-aefa-957fcebbd259"), 95, "", 0, "Bedroom|Dressing" },
                    { new Guid("36d6c59c-ecea-4838-bf8c-9201202d8aff"), 132, "", 0, "Bedroom|Cleaning" },
                    { new Guid("419963e9-d544-4568-a4a5-566ad8331fc5"), 1063, "", 0, "Bathroom|Showering" },
                    { new Guid("44337f76-9ff3-422a-84e2-7e8497836844"), 53, "", 0, "Staircase|Going_up" },
                    { new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), 9225, "", 0, "Office|Computing" },
                    { new Guid("6a064188-f5f4-4c03-82f5-7bc91fb706ca"), 90, "", 0, "Living_room|Cleaning" },
                    { new Guid("6b6e5e84-ad35-48d7-893e-04a985453ef2"), 177, "", 0, "Bathroom|Cleaning" },
                    { new Guid("87fc718e-898c-499a-a6f4-03c8405f0808"), 222, "", 0, "Bathroom|Using_the_toilet" },
                    { new Guid("9c8ff592-e175-46a3-8d6d-2e63055ee950"), 1646, "", 0, "Bedroom|Napping" },
                    { new Guid("a2ecbf24-3d6c-4f69-af7b-b977bde05558"), 381, "", 0, "Kitchen|Washing_the_dishes" },
                    { new Guid("bf8b6585-e818-4b69-a52b-7af4955fdf49"), 1668, "", 0, "Living_room|Watching_TV" },
                    { new Guid("ce2ec480-d55b-498e-bf9c-13147ae3c543"), 53, "", 0, "Staircase|Going_down" },
                    { new Guid("d4f79c1f-0be2-448d-81a0-c97f135fff22"), 712, "", 0, "Living_room|Eating" },
                    { new Guid("d955fe65-2ace-4631-adc6-9d01b238d787"), 119, "", 0, "Kitchen|Cleaning" },
                    { new Guid("e4590636-080a-4fe1-840b-6c81bdcfd06f"), 152, "", 0, "Office|Cleaning" },
                    { new Guid("f3bd068d-fb68-4874-8af8-5f2e66ed028d"), 1147, "", 0, "Office|Watching_TV" },
                    { new Guid("fc675763-5211-430d-9c19-5b612056cb58"), 1738, "", 0, "Bedroom|Reading" }
                });

            migrationBuilder.InsertData(
                table: "NextAction",
                columns: new[] { "ActionAggregateId", "Id", "Delay", "Possibility" },
                values: new object[,]
                {
                    { new Guid("0f2f7417-6e6f-4d56-8dec-a0a9dd918154"), new Guid("0643e948-3429-4782-b163-20e9ea995d2d"), 1, 38 },
                    { new Guid("6a064188-f5f4-4c03-82f5-7bc91fb706ca"), new Guid("0643e948-3429-4782-b163-20e9ea995d2d"), 1, 63 },
                    { new Guid("ce2ec480-d55b-498e-bf9c-13147ae3c543"), new Guid("0c536f44-97c8-4188-a575-b840ca17f2d3"), 1, 36 },
                    { new Guid("0643e948-3429-4782-b163-20e9ea995d2d"), new Guid("0f2f7417-6e6f-4d56-8dec-a0a9dd918154"), 1, 7 },
                    { new Guid("09cbb4f4-b294-4e31-98e0-4937c829352a"), new Guid("0f2f7417-6e6f-4d56-8dec-a0a9dd918154"), 1, 5 },
                    { new Guid("6a064188-f5f4-4c03-82f5-7bc91fb706ca"), new Guid("0f2f7417-6e6f-4d56-8dec-a0a9dd918154"), 1, 16 },
                    { new Guid("bf8b6585-e818-4b69-a52b-7af4955fdf49"), new Guid("0f2f7417-6e6f-4d56-8dec-a0a9dd918154"), 1, 12 },
                    { new Guid("d955fe65-2ace-4631-adc6-9d01b238d787"), new Guid("0f2f7417-6e6f-4d56-8dec-a0a9dd918154"), 1, 25 },
                    { new Guid("419963e9-d544-4568-a4a5-566ad8331fc5"), new Guid("24f6ae4b-6f99-4e54-865e-748e8297a25c"), 1, 100 },
                    { new Guid("44337f76-9ff3-422a-84e2-7e8497836844"), new Guid("24f6ae4b-6f99-4e54-865e-748e8297a25c"), 1, 31 },
                    { new Guid("87fc718e-898c-499a-a6f4-03c8405f0808"), new Guid("24f6ae4b-6f99-4e54-865e-748e8297a25c"), 1, 11 },
                    { new Guid("ce2ec480-d55b-498e-bf9c-13147ae3c543"), new Guid("25deeb4d-2fc1-4a21-9ab5-8cda61cb3eef"), 1, 33 },
                    { new Guid("25deeb4d-2fc1-4a21-9ab5-8cda61cb3eef"), new Guid("2c575e89-f134-420f-a5b4-a3c665adc741"), 1, 100 },
                    { new Guid("24f6ae4b-6f99-4e54-865e-748e8297a25c"), new Guid("3184275d-3c14-408c-aefa-957fcebbd259"), 1, 39 },
                    { new Guid("9c8ff592-e175-46a3-8d6d-2e63055ee950"), new Guid("3184275d-3c14-408c-aefa-957fcebbd259"), 1, 100 },
                    { new Guid("6b6e5e84-ad35-48d7-893e-04a985453ef2"), new Guid("36d6c59c-ecea-4838-bf8c-9201202d8aff"), 1, 75 },
                    { new Guid("44337f76-9ff3-422a-84e2-7e8497836844"), new Guid("419963e9-d544-4568-a4a5-566ad8331fc5"), 1, 33 },
                    { new Guid("0643e948-3429-4782-b163-20e9ea995d2d"), new Guid("44337f76-9ff3-422a-84e2-7e8497836844"), 1, 93 },
                    { new Guid("09cbb4f4-b294-4e31-98e0-4937c829352a"), new Guid("44337f76-9ff3-422a-84e2-7e8497836844"), 1, 90 },
                    { new Guid("0f2f7417-6e6f-4d56-8dec-a0a9dd918154"), new Guid("44337f76-9ff3-422a-84e2-7e8497836844"), 1, 62 },
                    { new Guid("bf8b6585-e818-4b69-a52b-7af4955fdf49"), new Guid("44337f76-9ff3-422a-84e2-7e8497836844"), 1, 88 },
                    { new Guid("d955fe65-2ace-4631-adc6-9d01b238d787"), new Guid("44337f76-9ff3-422a-84e2-7e8497836844"), 1, 75 },
                    { new Guid("24f6ae4b-6f99-4e54-865e-748e8297a25c"), new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), 1, 6 },
                    { new Guid("3184275d-3c14-408c-aefa-957fcebbd259"), new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), 1, 46 },
                    { new Guid("36d6c59c-ecea-4838-bf8c-9201202d8aff"), new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), 1, 100 },
                    { new Guid("44337f76-9ff3-422a-84e2-7e8497836844"), new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), 1, 33 },
                    { new Guid("6b6e5e84-ad35-48d7-893e-04a985453ef2"), new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), 1, 25 },
                    { new Guid("87fc718e-898c-499a-a6f4-03c8405f0808"), new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), 1, 77 },
                    { new Guid("a2ecbf24-3d6c-4f69-af7b-b977bde05558"), new Guid("6a064188-f5f4-4c03-82f5-7bc91fb706ca"), 1, 100 },
                    { new Guid("24f6ae4b-6f99-4e54-865e-748e8297a25c"), new Guid("6b6e5e84-ad35-48d7-893e-04a985453ef2"), 1, 8 },
                    { new Guid("87fc718e-898c-499a-a6f4-03c8405f0808"), new Guid("6b6e5e84-ad35-48d7-893e-04a985453ef2"), 1, 12 },
                    { new Guid("24f6ae4b-6f99-4e54-865e-748e8297a25c"), new Guid("87fc718e-898c-499a-a6f4-03c8405f0808"), 1, 3 },
                    { new Guid("3184275d-3c14-408c-aefa-957fcebbd259"), new Guid("87fc718e-898c-499a-a6f4-03c8405f0808"), 1, 4 },
                    { new Guid("44337f76-9ff3-422a-84e2-7e8497836844"), new Guid("87fc718e-898c-499a-a6f4-03c8405f0808"), 1, 3 },
                    { new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), new Guid("87fc718e-898c-499a-a6f4-03c8405f0808"), 1, 13 },
                    { new Guid("fc675763-5211-430d-9c19-5b612056cb58"), new Guid("9c8ff592-e175-46a3-8d6d-2e63055ee950"), 1, 100 },
                    { new Guid("d4f79c1f-0be2-448d-81a0-c97f135fff22"), new Guid("a2ecbf24-3d6c-4f69-af7b-b977bde05558"), 1, 100 },
                    { new Guid("09cbb4f4-b294-4e31-98e0-4937c829352a"), new Guid("bf8b6585-e818-4b69-a52b-7af4955fdf49"), 1, 6 },
                    { new Guid("ce2ec480-d55b-498e-bf9c-13147ae3c543"), new Guid("bf8b6585-e818-4b69-a52b-7af4955fdf49"), 1, 29 },
                    { new Guid("24f6ae4b-6f99-4e54-865e-748e8297a25c"), new Guid("ce2ec480-d55b-498e-bf9c-13147ae3c543"), 1, 44 },
                    { new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), new Guid("ce2ec480-d55b-498e-bf9c-13147ae3c543"), 1, 47 },
                    { new Guid("e4590636-080a-4fe1-840b-6c81bdcfd06f"), new Guid("ce2ec480-d55b-498e-bf9c-13147ae3c543"), 1, 100 },
                    { new Guid("f3bd068d-fb68-4874-8af8-5f2e66ed028d"), new Guid("ce2ec480-d55b-498e-bf9c-13147ae3c543"), 1, 100 },
                    { new Guid("2c575e89-f134-420f-a5b4-a3c665adc741"), new Guid("d4f79c1f-0be2-448d-81a0-c97f135fff22"), 1, 100 },
                    { new Guid("6a064188-f5f4-4c03-82f5-7bc91fb706ca"), new Guid("d955fe65-2ace-4631-adc6-9d01b238d787"), 1, 21 },
                    { new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), new Guid("e4590636-080a-4fe1-840b-6c81bdcfd06f"), 1, 10 },
                    { new Guid("59c69ddc-7f2a-4241-be3b-74ccabc8a03a"), new Guid("f3bd068d-fb68-4874-8af8-5f2e66ed028d"), 1, 30 },
                    { new Guid("3184275d-3c14-408c-aefa-957fcebbd259"), new Guid("fc675763-5211-430d-9c19-5b612056cb58"), 1, 50 }
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
