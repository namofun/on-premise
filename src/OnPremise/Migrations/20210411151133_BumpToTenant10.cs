using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SatelliteSite.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20210411151133_BumpToTenant10")]
    public partial class BumpToTenant10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenantVerifyCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 16, nullable: false),
                    AffiliationId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RedeemCount = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantVerifyCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantVerifyCodes_TenantAffiliation_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "TenantAffiliation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantVerifyCodes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantVerifyCodes_AffiliationId",
                table: "TenantVerifyCodes",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantVerifyCodes_Code",
                table: "TenantVerifyCodes",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TenantVerifyCodes_UserId",
                table: "TenantVerifyCodes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantVerifyCodes");
        }
    }
}
