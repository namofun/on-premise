using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SatelliteSite.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20210502093528_BumpToPolygon18")]
    public partial class BumpToPolygon18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolygonVersion",
                table: "PolygonJudgings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RunVerdicts",
                table: "PolygonJudgings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolygonVersion",
                table: "PolygonJudgings");

            migrationBuilder.DropColumn(
                name: "RunVerdicts",
                table: "PolygonJudgings");
        }
    }
}
