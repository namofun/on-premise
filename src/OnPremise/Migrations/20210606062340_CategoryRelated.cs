using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SatelliteSite.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20210606062340_CategoryRelated")]
    public partial class CategoryRelated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContestBalloons_SubmissionId",
                table: "ContestBalloons");

            migrationBuilder.AddColumn<int>(
                name: "ContestId",
                table: "TenantCategory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastAcPublic",
                table: "ContestRankCache",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastAcRestricted",
                table: "ContestRankCache",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ContestBalloons_SubmissionId",
                table: "ContestBalloons",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantCategory_ContestId",
                table: "TenantCategory",
                column: "ContestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantCategory_Contests_ContestId",
                table: "TenantCategory",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantCategory_Contests_ContestId",
                table: "TenantCategory");

            migrationBuilder.DropIndex(
                name: "IX_TenantCategory_ContestId",
                table: "TenantCategory");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ContestBalloons_SubmissionId",
                table: "ContestBalloons");

            migrationBuilder.DropColumn(
                name: "ContestId",
                table: "TenantCategory");

            migrationBuilder.DropColumn(
                name: "LastAcPublic",
                table: "ContestRankCache");

            migrationBuilder.DropColumn(
                name: "LastAcRestricted",
                table: "ContestRankCache");

            migrationBuilder.CreateIndex(
                name: "IX_ContestBalloons_SubmissionId",
                table: "ContestBalloons",
                column: "SubmissionId");
        }
    }
}
