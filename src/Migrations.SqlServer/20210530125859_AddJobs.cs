using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SatelliteSite.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20210530125859_AddJobs")]
    public partial class AddJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    CompleteTime = table.Column<DateTimeOffset>(nullable: true),
                    ParentJobId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Composite = table.Column<bool>(nullable: false),
                    SuggestedFileName = table.Column<string>(nullable: true),
                    JobType = table.Column<string>(nullable: true),
                    Arguments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Jobs_ParentJobId",
                        column: x => x.ParentJobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "ShortName" },
                values: new object[] { -37, "76133040-8512-5021-491b-563056c3f919", "Plagiarism Detect User", "PlagUser", "PLAGUSER", "plaguser" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CreationTime",
                table: "Jobs",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_OwnerId",
                table: "Jobs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ParentJobId",
                table: "Jobs",
                column: "ParentJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Status",
                table: "Jobs",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: -37);
        }
    }
}
