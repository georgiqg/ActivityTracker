using Microsoft.EntityFrameworkCore.Migrations;

namespace ActivityTracker.Migrations
{
    public partial class OptionalFieldsActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_CustomUnit_CustomUnitId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Unit_UnitId",
                table: "Activity");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Activity",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomUnitId",
                table: "Activity",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_CustomUnit_CustomUnitId",
                table: "Activity",
                column: "CustomUnitId",
                principalTable: "CustomUnit",
                principalColumn: "CustomUnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Unit_UnitId",
                table: "Activity",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_CustomUnit_CustomUnitId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Unit_UnitId",
                table: "Activity");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Activity",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomUnitId",
                table: "Activity",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_CustomUnit_CustomUnitId",
                table: "Activity",
                column: "CustomUnitId",
                principalTable: "CustomUnit",
                principalColumn: "CustomUnitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Unit_UnitId",
                table: "Activity",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
