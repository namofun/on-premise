using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SatelliteSite.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20210404131835_PolygonSeeds")]
    public partial class PolygonSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Polygon.Storages.SeedMigrationV1.Up(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
