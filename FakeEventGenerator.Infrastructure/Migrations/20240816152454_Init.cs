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
                    { new Guid("3396a6c5-dfd8-43d0-8147-2a8629b2338e"), 712, "", 0, "Living_room|Eating" },
                    { new Guid("36456171-deb8-43bf-b497-1b56f3efdbdb"), 207, "", 0, "Bathroom|Using_the_sink" },
                    { new Guid("422cc46b-b29d-4b94-9824-934605a7abc7"), 53, "", 0, "Staircase|Going_up" },
                    { new Guid("43f44c50-bebc-4f0d-8701-f30d3fdc3766"), 89, "", 100, "Entrance|Leaving" },
                    { new Guid("4c7d5e2c-29b8-4355-ac37-62aafd9e035f"), 1738, "", 0, "Bedroom|Reading" },
                    { new Guid("5628217c-16af-4e86-b817-f25d746db9c9"), 119, "", 0, "Kitchen|Cleaning" },
                    { new Guid("5ce04ae0-9dd1-4f69-a464-35e54476a9a3"), 147, "", 0, "Toilet|Using_the_toilet" },
                    { new Guid("6671a582-af36-4e59-8acd-aae99ed53dcd"), 90, "", 0, "Living_room|Cleaning" },
                    { new Guid("745122e5-347e-4c3f-ac2d-216b7de085f7"), 381, "", 0, "Kitchen|Washing_the_dishes" },
                    { new Guid("7c11b156-8ce9-4fb2-a471-1c9f808432fe"), 131, "", 0, "Entrance|Entering" },
                    { new Guid("7d2af24d-2176-4a63-9cf2-f1123630a71c"), 1147, "", 0, "Office|Watching_TV" },
                    { new Guid("8c62c06f-5b82-456a-9909-be0cd3bba7cb"), 1882, "", 0, "Living_room|Computing" },
                    { new Guid("94434109-6779-48d6-a726-4eef79755df9"), 1646, "", 0, "Bedroom|Napping" },
                    { new Guid("b0000a96-0c63-4c0c-955b-a24b18117ea1"), 692, "", 0, "Kitchen|Cooking" },
                    { new Guid("b3056bb2-b38f-4792-ab66-ab7d2cff88e7"), 152, "", 0, "Office|Cleaning" },
                    { new Guid("b6fe9a9a-01f0-490b-a6b3-b76a5d2fc3ae"), 222, "", 0, "Bathroom|Using_the_toilet" },
                    { new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), 9225, "", 0, "Office|Computing" },
                    { new Guid("c4f2f3ae-99a4-417a-be15-2e4bcfba4530"), 95, "", 0, "Bedroom|Dressing" },
                    { new Guid("c855f4c9-6c86-4253-865e-dfeafc3299bb"), 177, "", 0, "Bathroom|Cleaning" },
                    { new Guid("cd2872c3-8575-4025-a803-fa03106f440a"), 1668, "", 0, "Living_room|Watching_TV" },
                    { new Guid("d0e2f0b7-4f70-409f-a59f-f0a5cc16d909"), 53, "", 0, "Staircase|Going_down" },
                    { new Guid("d1a54cf2-e4bc-474c-aadc-fe2d0abe8a90"), 132, "", 0, "Bedroom|Cleaning" },
                    { new Guid("d2acf5db-3126-4491-84e4-f49ee41d1d25"), 112, "", 0, "Kitchen|Preparing" },
                    { new Guid("f65cf285-02b7-4af5-af05-d0fb0e68da42"), 1063, "", 0, "Bathroom|Showering" }
                });

            migrationBuilder.InsertData(
                table: "NextAction",
                columns: new[] { "ActionAggregateId", "Id", "Delay", "Possibility" },
                values: new object[,]
                {
                    { new Guid("b0000a96-0c63-4c0c-955b-a24b18117ea1"), new Guid("3396a6c5-dfd8-43d0-8147-2a8629b2338e"), 1, 100 },
                    { new Guid("422cc46b-b29d-4b94-9824-934605a7abc7"), new Guid("36456171-deb8-43bf-b497-1b56f3efdbdb"), 1, 31 },
                    { new Guid("b6fe9a9a-01f0-490b-a6b3-b76a5d2fc3ae"), new Guid("36456171-deb8-43bf-b497-1b56f3efdbdb"), 1, 11 },
                    { new Guid("f65cf285-02b7-4af5-af05-d0fb0e68da42"), new Guid("36456171-deb8-43bf-b497-1b56f3efdbdb"), 1, 100 },
                    { new Guid("5628217c-16af-4e86-b817-f25d746db9c9"), new Guid("422cc46b-b29d-4b94-9824-934605a7abc7"), 1, 75 },
                    { new Guid("5ce04ae0-9dd1-4f69-a464-35e54476a9a3"), new Guid("422cc46b-b29d-4b94-9824-934605a7abc7"), 1, 62 },
                    { new Guid("7c11b156-8ce9-4fb2-a471-1c9f808432fe"), new Guid("422cc46b-b29d-4b94-9824-934605a7abc7"), 1, 90 },
                    { new Guid("8c62c06f-5b82-456a-9909-be0cd3bba7cb"), new Guid("422cc46b-b29d-4b94-9824-934605a7abc7"), 1, 93 },
                    { new Guid("cd2872c3-8575-4025-a803-fa03106f440a"), new Guid("422cc46b-b29d-4b94-9824-934605a7abc7"), 1, 88 },
                    { new Guid("d0e2f0b7-4f70-409f-a59f-f0a5cc16d909"), new Guid("43f44c50-bebc-4f0d-8701-f30d3fdc3766"), 1, 36 },
                    { new Guid("c4f2f3ae-99a4-417a-be15-2e4bcfba4530"), new Guid("4c7d5e2c-29b8-4355-ac37-62aafd9e035f"), 1, 50 },
                    { new Guid("6671a582-af36-4e59-8acd-aae99ed53dcd"), new Guid("5628217c-16af-4e86-b817-f25d746db9c9"), 1, 21 },
                    { new Guid("5628217c-16af-4e86-b817-f25d746db9c9"), new Guid("5ce04ae0-9dd1-4f69-a464-35e54476a9a3"), 1, 25 },
                    { new Guid("6671a582-af36-4e59-8acd-aae99ed53dcd"), new Guid("5ce04ae0-9dd1-4f69-a464-35e54476a9a3"), 1, 16 },
                    { new Guid("7c11b156-8ce9-4fb2-a471-1c9f808432fe"), new Guid("5ce04ae0-9dd1-4f69-a464-35e54476a9a3"), 1, 5 },
                    { new Guid("8c62c06f-5b82-456a-9909-be0cd3bba7cb"), new Guid("5ce04ae0-9dd1-4f69-a464-35e54476a9a3"), 1, 7 },
                    { new Guid("cd2872c3-8575-4025-a803-fa03106f440a"), new Guid("5ce04ae0-9dd1-4f69-a464-35e54476a9a3"), 1, 12 },
                    { new Guid("745122e5-347e-4c3f-ac2d-216b7de085f7"), new Guid("6671a582-af36-4e59-8acd-aae99ed53dcd"), 1, 100 },
                    { new Guid("3396a6c5-dfd8-43d0-8147-2a8629b2338e"), new Guid("745122e5-347e-4c3f-ac2d-216b7de085f7"), 1, 100 },
                    { new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), new Guid("7d2af24d-2176-4a63-9cf2-f1123630a71c"), 1, 30 },
                    { new Guid("5ce04ae0-9dd1-4f69-a464-35e54476a9a3"), new Guid("8c62c06f-5b82-456a-9909-be0cd3bba7cb"), 1, 38 },
                    { new Guid("6671a582-af36-4e59-8acd-aae99ed53dcd"), new Guid("8c62c06f-5b82-456a-9909-be0cd3bba7cb"), 1, 63 },
                    { new Guid("4c7d5e2c-29b8-4355-ac37-62aafd9e035f"), new Guid("94434109-6779-48d6-a726-4eef79755df9"), 1, 100 },
                    { new Guid("d2acf5db-3126-4491-84e4-f49ee41d1d25"), new Guid("b0000a96-0c63-4c0c-955b-a24b18117ea1"), 1, 100 },
                    { new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), new Guid("b3056bb2-b38f-4792-ab66-ab7d2cff88e7"), 1, 10 },
                    { new Guid("36456171-deb8-43bf-b497-1b56f3efdbdb"), new Guid("b6fe9a9a-01f0-490b-a6b3-b76a5d2fc3ae"), 1, 3 },
                    { new Guid("422cc46b-b29d-4b94-9824-934605a7abc7"), new Guid("b6fe9a9a-01f0-490b-a6b3-b76a5d2fc3ae"), 1, 3 },
                    { new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), new Guid("b6fe9a9a-01f0-490b-a6b3-b76a5d2fc3ae"), 1, 13 },
                    { new Guid("c4f2f3ae-99a4-417a-be15-2e4bcfba4530"), new Guid("b6fe9a9a-01f0-490b-a6b3-b76a5d2fc3ae"), 1, 4 },
                    { new Guid("36456171-deb8-43bf-b497-1b56f3efdbdb"), new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), 1, 6 },
                    { new Guid("422cc46b-b29d-4b94-9824-934605a7abc7"), new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), 1, 33 },
                    { new Guid("b6fe9a9a-01f0-490b-a6b3-b76a5d2fc3ae"), new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), 1, 77 },
                    { new Guid("c4f2f3ae-99a4-417a-be15-2e4bcfba4530"), new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), 1, 46 },
                    { new Guid("c855f4c9-6c86-4253-865e-dfeafc3299bb"), new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), 1, 25 },
                    { new Guid("d1a54cf2-e4bc-474c-aadc-fe2d0abe8a90"), new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), 1, 100 },
                    { new Guid("36456171-deb8-43bf-b497-1b56f3efdbdb"), new Guid("c4f2f3ae-99a4-417a-be15-2e4bcfba4530"), 1, 39 },
                    { new Guid("94434109-6779-48d6-a726-4eef79755df9"), new Guid("c4f2f3ae-99a4-417a-be15-2e4bcfba4530"), 1, 100 },
                    { new Guid("36456171-deb8-43bf-b497-1b56f3efdbdb"), new Guid("c855f4c9-6c86-4253-865e-dfeafc3299bb"), 1, 8 },
                    { new Guid("b6fe9a9a-01f0-490b-a6b3-b76a5d2fc3ae"), new Guid("c855f4c9-6c86-4253-865e-dfeafc3299bb"), 1, 12 },
                    { new Guid("7c11b156-8ce9-4fb2-a471-1c9f808432fe"), new Guid("cd2872c3-8575-4025-a803-fa03106f440a"), 1, 6 },
                    { new Guid("d0e2f0b7-4f70-409f-a59f-f0a5cc16d909"), new Guid("cd2872c3-8575-4025-a803-fa03106f440a"), 1, 29 },
                    { new Guid("36456171-deb8-43bf-b497-1b56f3efdbdb"), new Guid("d0e2f0b7-4f70-409f-a59f-f0a5cc16d909"), 1, 44 },
                    { new Guid("7d2af24d-2176-4a63-9cf2-f1123630a71c"), new Guid("d0e2f0b7-4f70-409f-a59f-f0a5cc16d909"), 1, 100 },
                    { new Guid("b3056bb2-b38f-4792-ab66-ab7d2cff88e7"), new Guid("d0e2f0b7-4f70-409f-a59f-f0a5cc16d909"), 1, 100 },
                    { new Guid("baa9e157-fd12-41b5-b7f7-119d006d91d8"), new Guid("d0e2f0b7-4f70-409f-a59f-f0a5cc16d909"), 1, 47 },
                    { new Guid("c855f4c9-6c86-4253-865e-dfeafc3299bb"), new Guid("d1a54cf2-e4bc-474c-aadc-fe2d0abe8a90"), 1, 75 },
                    { new Guid("d0e2f0b7-4f70-409f-a59f-f0a5cc16d909"), new Guid("d2acf5db-3126-4491-84e4-f49ee41d1d25"), 1, 33 },
                    { new Guid("422cc46b-b29d-4b94-9824-934605a7abc7"), new Guid("f65cf285-02b7-4af5-af05-d0fb0e68da42"), 1, 33 }
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
