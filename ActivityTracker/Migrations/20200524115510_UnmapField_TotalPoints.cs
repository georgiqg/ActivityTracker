using Microsoft.EntityFrameworkCore.Migrations;

namespace ActivityTracker.Migrations
{
    public partial class UnmapField_TotalPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPoints",
                table: "ActivityLog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPoints",
                table: "ActivityLog",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
