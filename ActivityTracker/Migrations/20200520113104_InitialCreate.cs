using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ActivityTracker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomUnit",
                columns: table => new
                {
                    CustomUnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    CustomUnitName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomUnit", x => x.CustomUnitId);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    ActivityName = table.Column<string>(maxLength: 100, nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    CustomUnitId = table.Column<int>(nullable: false),
                    PointsPerUnit = table.Column<int>(nullable: false),
                    MaxPointsPerDay = table.Column<int>(nullable: false),
                    ActivityValidFrom = table.Column<DateTime>(nullable: false),
                    ActivityValidTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activity_CustomUnit_CustomUnitId",
                        column: x => x.CustomUnitId,
                        principalTable: "CustomUnit",
                        principalColumn: "CustomUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    ActivityLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(nullable: false),
                    LogDate = table.Column<DateTime>(nullable: false),
                    Units = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.ActivityLogId);
                    table.ForeignKey(
                        name: "FK_ActivityLog_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_CustomUnitId",
                table: "Activity",
                column: "CustomUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_UnitId",
                table: "Activity",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_ActivityId",
                table: "ActivityLog",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "CustomUnit");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
