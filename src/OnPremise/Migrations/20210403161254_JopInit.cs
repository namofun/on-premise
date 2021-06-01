using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SatelliteSite.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20210403161254_JopInit")]
    public partial class JopInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auditlogs",
                columns: table => new
                {
                    LogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTimeOffset>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    ContestId = table.Column<int>(nullable: true),
                    DataType = table.Column<int>(nullable: false),
                    DataId = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Action = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    ExtraInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditlogs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Name = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    Value = table.Column<string>(unicode: false, nullable: false),
                    Type = table.Column<string>(nullable: false),
                    DisplayPriority = table.Column<int>(nullable: false),
                    Public = table.Column<bool>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Contests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: true),
                    FreezeTime = table.Column<double>(nullable: true),
                    EndTime = table.Column<double>(nullable: true),
                    UnfreezeTime = table.Column<double>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    RankingStrategy = table.Column<int>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    SettingsJson = table.Column<string>(nullable: true),
                    TeamCount = table.Column<int>(nullable: false),
                    ProblemCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlagiarismSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ContestId = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ReportCount = table.Column<int>(nullable: false),
                    ReportPending = table.Column<int>(nullable: false),
                    SubmissionCount = table.Column<int>(nullable: false),
                    SubmissionFailed = table.Column<int>(nullable: false),
                    SubmissionSucceeded = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlagiarismSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolygonErrors",
                columns: table => new
                {
                    ErrorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContestId = table.Column<int>(nullable: true),
                    JudgingId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    JudgehostLog = table.Column<string>(nullable: false),
                    Time = table.Column<DateTimeOffset>(nullable: false),
                    Disabled = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonErrors", x => x.ErrorId);
                });

            migrationBuilder.CreateTable(
                name: "PolygonExecutables",
                columns: table => new
                {
                    ExecId = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    Md5sum = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    ZipFile = table.Column<byte[]>(maxLength: 1048576, nullable: false),
                    ZipSize = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonExecutables", x => x.ExecId);
                });

            migrationBuilder.CreateTable(
                name: "PolygonJudgehosts",
                columns: table => new
                {
                    ServerName = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PollTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonJudgehosts", x => x.ServerName);
                });

            migrationBuilder.CreateTable(
                name: "TenantAffiliation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Abbreviation = table.Column<string>(nullable: false),
                    EmailSuffix = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(unicode: false, maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantAffiliation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTime = table.Column<DateTimeOffset>(nullable: false),
                    ContestId = table.Column<int>(nullable: false),
                    EndpointType = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    EndpointId = table.Column<string>(maxLength: 32, nullable: false),
                    Action = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    Content = table.Column<string>(maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestEvents_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlagiarismSubmissions",
                columns: table => new
                {
                    SetId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExternalId = table.Column<Guid>(nullable: false),
                    ExclusiveCategory = table.Column<int>(nullable: false),
                    InclusiveCategory = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MaxPercent = table.Column<double>(nullable: false),
                    TokenProduced = table.Column<bool>(nullable: true),
                    UploadTime = table.Column<DateTimeOffset>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Error = table.Column<string>(nullable: true),
                    Tokens = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlagiarismSubmissions", x => new { x.SetId, x.Id });
                    table.UniqueConstraint("AK_PlagiarismSubmissions_ExternalId", x => x.ExternalId);
                    table.ForeignKey(
                        name: "FK_PlagiarismSubmissions_PlagiarismSets_SetId",
                        column: x => x.SetId,
                        principalTable: "PlagiarismSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolygonLanguages",
                columns: table => new
                {
                    LangId = table.Column<string>(unicode: false, maxLength: 16, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    AllowSubmit = table.Column<bool>(nullable: false),
                    AllowJudge = table.Column<bool>(nullable: false),
                    CompileScript = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    TimeFactor = table.Column<double>(nullable: false),
                    FileExtension = table.Column<string>(unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonLanguages", x => x.LangId);
                    table.ForeignKey(
                        name: "FK_PolygonLanguages_PolygonExecutables_CompileScript",
                        column: x => x.CompileScript,
                        principalTable: "PolygonExecutables",
                        principalColumn: "ExecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolygonProblems",
                columns: table => new
                {
                    ProblemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 128, nullable: false),
                    Source = table.Column<string>(maxLength: 256, nullable: false),
                    TagName = table.Column<string>(maxLength: 256, nullable: false),
                    AllowJudge = table.Column<bool>(nullable: false),
                    AllowSubmit = table.Column<bool>(nullable: false),
                    TimeLimit = table.Column<int>(nullable: false),
                    MemoryLimit = table.Column<int>(nullable: false),
                    OutputLimit = table.Column<int>(nullable: false),
                    RunScript = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    CompareScript = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    CompareArguments = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    CombinedRunCompare = table.Column<bool>(nullable: false),
                    Shared = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonProblems", x => x.ProblemId);
                    table.ForeignKey(
                        name: "FK_PolygonProblems_PolygonExecutables_CompareScript",
                        column: x => x.CompareScript,
                        principalTable: "PolygonExecutables",
                        principalColumn: "ExecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolygonProblems_PolygonExecutables_RunScript",
                        column: x => x.RunScript,
                        principalTable: "PolygonExecutables",
                        principalColumn: "ExecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestTenants",
                columns: table => new
                {
                    ContestId = table.Column<int>(nullable: false),
                    AffiliationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestTenants", x => new { x.ContestId, x.AffiliationId });
                    table.ForeignKey(
                        name: "FK_ContestTenants_TenantAffiliation_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "TenantAffiliation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestTenants_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantStudents",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 32, nullable: false),
                    AffiliationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantStudents_TenantAffiliation_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "TenantAffiliation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestTeams",
                columns: table => new
                {
                    ContestId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    TeamName = table.Column<string>(maxLength: 128, nullable: false),
                    AffiliationId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    RegisterTime = table.Column<DateTimeOffset>(nullable: true),
                    ContestTime = table.Column<DateTimeOffset>(nullable: true),
                    Location = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestTeams", x => new { x.ContestId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_ContestTeams_TenantAffiliation_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "TenantAffiliation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestTeams_TenantCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TenantCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestTeams_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlagiarismFiles",
                columns: table => new
                {
                    FileId = table.Column<int>(nullable: false),
                    SubmissionId = table.Column<Guid>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlagiarismFiles", x => new { x.SubmissionId, x.FileId });
                    table.ForeignKey(
                        name: "FK_PlagiarismFiles_PlagiarismSubmissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "PlagiarismSubmissions",
                        principalColumn: "ExternalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlagiarismReports",
                columns: table => new
                {
                    SetId = table.Column<Guid>(nullable: false),
                    SubmissionA = table.Column<int>(nullable: false),
                    SubmissionB = table.Column<int>(nullable: false),
                    ExternalId = table.Column<Guid>(nullable: false),
                    TokensMatched = table.Column<int>(nullable: false, defaultValue: 0),
                    BiggestMatch = table.Column<int>(nullable: false, defaultValue: 0),
                    Percent = table.Column<double>(nullable: false, defaultValue: 0.0),
                    PercentA = table.Column<double>(nullable: false, defaultValue: 0.0),
                    PercentB = table.Column<double>(nullable: false, defaultValue: 0.0),
                    Finished = table.Column<bool>(nullable: true),
                    Matches = table.Column<byte[]>(nullable: true),
                    Justification = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlagiarismReports", x => new { x.SetId, x.SubmissionA, x.SubmissionB });
                    table.UniqueConstraint("AK_PlagiarismReports_ExternalId", x => x.ExternalId);
                    table.ForeignKey(
                        name: "FK_PlagiarismReports_PlagiarismSets_SetId",
                        column: x => x.SetId,
                        principalTable: "PlagiarismSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlagiarismReports_PlagiarismSubmissions_SetId_SubmissionA",
                        columns: x => new { x.SetId, x.SubmissionA },
                        principalTable: "PlagiarismSubmissions",
                        principalColumns: new[] { "SetId", "Id" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlagiarismReports_PlagiarismSubmissions_SetId_SubmissionB",
                        columns: x => new { x.SetId, x.SubmissionB },
                        principalTable: "PlagiarismSubmissions",
                        principalColumns: new[] { "SetId", "Id" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestProblems",
                columns: table => new
                {
                    ContestId = table.Column<int>(nullable: false),
                    ProblemId = table.Column<int>(nullable: false),
                    ShortName = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    AllowSubmit = table.Column<bool>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestProblems", x => new { x.ContestId, x.ProblemId });
                    table.ForeignKey(
                        name: "FK_ContestProblems_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestProblems_PolygonProblems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "PolygonProblems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolygonStatistics",
                columns: table => new
                {
                    ProblemId = table.Column<int>(nullable: false),
                    ContestId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    TotalSubmission = table.Column<int>(nullable: false),
                    AcceptedSubmission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonStatistics", x => new { x.ContestId, x.TeamId, x.ProblemId });
                    table.ForeignKey(
                        name: "FK_PolygonStatistics_PolygonProblems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "PolygonProblems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolygonTestcases",
                columns: table => new
                {
                    TestcaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemId = table.Column<int>(nullable: false),
                    IsSecret = table.Column<bool>(nullable: false),
                    Md5sumInput = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    Md5sumOutput = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    InputLength = table.Column<int>(nullable: false),
                    OutputLength = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Point = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: false),
                    CustomInput = table.Column<string>(nullable: true),
                    CustomOutput = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonTestcases", x => x.TestcaseId);
                    table.ForeignKey(
                        name: "FK_PolygonTestcases_PolygonProblems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "PolygonProblems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    NickName = table.Column<string>(maxLength: 256, nullable: true),
                    Plan = table.Column<string>(nullable: true),
                    RegisterTime = table.Column<DateTimeOffset>(nullable: true),
                    SubscribeNews = table.Column<bool>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    StudentEmail = table.Column<string>(nullable: true),
                    StudentVerified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TenantStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "TenantStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ContestClarifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContestId = table.Column<int>(nullable: false),
                    ResponseToId = table.Column<int>(nullable: true),
                    SubmitTime = table.Column<DateTimeOffset>(nullable: false),
                    Sender = table.Column<int>(nullable: true),
                    Recipient = table.Column<int>(nullable: true),
                    JuryMember = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    ProblemId = table.Column<int>(nullable: true),
                    Body = table.Column<string>(nullable: false),
                    Answered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestClarifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestClarifications_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestClarifications_PolygonProblems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "PolygonProblems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestClarifications_ContestClarifications_ResponseToId",
                        column: x => x.ResponseToId,
                        principalTable: "ContestClarifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestClarifications_ContestTeams_ContestId_Recipient",
                        columns: x => new { x.ContestId, x.Recipient },
                        principalTable: "ContestTeams",
                        principalColumns: new[] { "ContestId", "TeamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestClarifications_ContestTeams_ContestId_Sender",
                        columns: x => new { x.ContestId, x.Sender },
                        principalTable: "ContestTeams",
                        principalColumns: new[] { "ContestId", "TeamId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestRankCache",
                columns: table => new
                {
                    ContestId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    PointsRestricted = table.Column<int>(nullable: false, defaultValue: 0),
                    TotalTimeRestricted = table.Column<int>(nullable: false, defaultValue: 0),
                    PointsPublic = table.Column<int>(nullable: false, defaultValue: 0),
                    TotalTimePublic = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestRankCache", x => new { x.ContestId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_ContestRankCache_ContestTeams_ContestId_TeamId",
                        columns: x => new { x.ContestId, x.TeamId },
                        principalTable: "ContestTeams",
                        principalColumns: new[] { "ContestId", "TeamId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestScoreCache",
                columns: table => new
                {
                    ContestId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    ProblemId = table.Column<int>(nullable: false),
                    SubmissionRestricted = table.Column<int>(nullable: false, defaultValue: 0),
                    PendingRestricted = table.Column<int>(nullable: false, defaultValue: 0),
                    SolveTimeRestricted = table.Column<double>(nullable: true),
                    ScoreRestricted = table.Column<int>(nullable: true),
                    IsCorrectRestricted = table.Column<bool>(nullable: false, defaultValue: false),
                    SubmissionPublic = table.Column<int>(nullable: false, defaultValue: 0),
                    PendingPublic = table.Column<int>(nullable: false, defaultValue: 0),
                    SolveTimePublic = table.Column<double>(nullable: true),
                    ScorePublic = table.Column<int>(nullable: true),
                    IsCorrectPublic = table.Column<bool>(nullable: false, defaultValue: false),
                    FirstToSolve = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestScoreCache", x => new { x.ContestId, x.TeamId, x.ProblemId });
                    table.ForeignKey(
                        name: "FK_ContestScoreCache_ContestTeams_ContestId_TeamId",
                        columns: x => new { x.ContestId, x.TeamId },
                        principalTable: "ContestTeams",
                        principalColumns: new[] { "ContestId", "TeamId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestJury",
                columns: table => new
                {
                    ContestId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestJury", x => new { x.ContestId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ContestJury_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestJury_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestMembers",
                columns: table => new
                {
                    ContestId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Temporary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestMembers", x => new { x.ContestId, x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ContestMembers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestMembers_ContestTeams_ContestId_TeamId",
                        columns: x => new { x.ContestId, x.TeamId },
                        principalTable: "ContestTeams",
                        principalColumns: new[] { "ContestId", "TeamId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestPrintings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTimeOffset>(nullable: false),
                    ContestId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Done = table.Column<bool>(nullable: true),
                    SourceCode = table.Column<byte[]>(maxLength: 65536, nullable: false),
                    FileName = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    LanguageId = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestPrintings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestPrintings_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestPrintings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolygonAuthors",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ProblemId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonAuthors", x => new { x.UserId, x.ProblemId });
                    table.ForeignKey(
                        name: "FK_PolygonAuthors_PolygonProblems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "PolygonProblems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolygonAuthors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolygonRejudgings",
                columns: table => new
                {
                    RejudgingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContestId = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: true),
                    EndTime = table.Column<DateTimeOffset>(nullable: true),
                    IssuedBy = table.Column<int>(nullable: true),
                    OperatedBy = table.Column<int>(nullable: true),
                    Applied = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonRejudgings", x => x.RejudgingId);
                    table.ForeignKey(
                        name: "FK_PolygonRejudgings_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolygonRejudgings_AspNetUsers_IssuedBy",
                        column: x => x.IssuedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolygonRejudgings_AspNetUsers_OperatedBy",
                        column: x => x.OperatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TenantTeachingClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantTeachingClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantTeachingClasses_TenantAffiliation_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "TenantAffiliation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TenantTeachingClasses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolygonSubmissions",
                columns: table => new
                {
                    SubmissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTimeOffset>(nullable: false),
                    ContestId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    ProblemId = table.Column<int>(nullable: false),
                    SourceCode = table.Column<string>(unicode: false, maxLength: 262144, nullable: false),
                    CodeLength = table.Column<int>(nullable: false),
                    Language = table.Column<string>(unicode: false, maxLength: 16, nullable: false),
                    Ip = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    ExpectedResult = table.Column<int>(nullable: true),
                    RejudgingId = table.Column<int>(nullable: true),
                    Ignored = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonSubmissions", x => x.SubmissionId);
                    table.ForeignKey(
                        name: "FK_PolygonSubmissions_PolygonLanguages_Language",
                        column: x => x.Language,
                        principalTable: "PolygonLanguages",
                        principalColumn: "LangId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolygonSubmissions_PolygonProblems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "PolygonProblems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolygonSubmissions_PolygonRejudgings_RejudgingId",
                        column: x => x.RejudgingId,
                        principalTable: "PolygonRejudgings",
                        principalColumn: "RejudgingId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TenantClassStudents",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantClassStudents", x => new { x.StudentId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_TenantClassStudents_TenantTeachingClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "TenantTeachingClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantClassStudents_TenantStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "TenantStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestBalloons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(nullable: false),
                    Done = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestBalloons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestBalloons_PolygonSubmissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "PolygonSubmissions",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolygonJudgings",
                columns: table => new
                {
                    JudgingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    FullTest = table.Column<bool>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: true),
                    StopTime = table.Column<DateTimeOffset>(nullable: true),
                    Server = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ExecuteTime = table.Column<int>(nullable: true),
                    ExecuteMemory = table.Column<int>(nullable: true),
                    CompileError = table.Column<string>(unicode: false, maxLength: 131072, nullable: true),
                    RejudgingId = table.Column<int>(nullable: true),
                    PreviousJudgingId = table.Column<int>(nullable: true),
                    TotalScore = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonJudgings", x => x.JudgingId);
                    table.ForeignKey(
                        name: "FK_PolygonJudgings_PolygonJudgings_PreviousJudgingId",
                        column: x => x.PreviousJudgingId,
                        principalTable: "PolygonJudgings",
                        principalColumn: "JudgingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolygonJudgings_PolygonRejudgings_RejudgingId",
                        column: x => x.RejudgingId,
                        principalTable: "PolygonRejudgings",
                        principalColumn: "RejudgingId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PolygonJudgings_PolygonJudgehosts_Server",
                        column: x => x.Server,
                        principalTable: "PolygonJudgehosts",
                        principalColumn: "ServerName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolygonJudgings_PolygonSubmissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "PolygonSubmissions",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolygonJudgingRuns",
                columns: table => new
                {
                    RunId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    JudgingId = table.Column<int>(nullable: false),
                    TestcaseId = table.Column<int>(nullable: false),
                    ExecuteMemory = table.Column<int>(nullable: false),
                    ExecuteTime = table.Column<int>(nullable: false),
                    CompleteTime = table.Column<DateTimeOffset>(nullable: false),
                    MetaData = table.Column<string>(unicode: false, maxLength: 131072, nullable: false),
                    OutputSystem = table.Column<string>(unicode: false, maxLength: 131072, nullable: false),
                    OutputDiff = table.Column<string>(unicode: false, maxLength: 131072, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonJudgingRuns", x => x.RunId);
                    table.ForeignKey(
                        name: "FK_PolygonJudgingRuns_PolygonJudgings_JudgingId",
                        column: x => x.JudgingId,
                        principalTable: "PolygonJudgings",
                        principalColumn: "JudgingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolygonJudgingRuns_PolygonTestcases_TestcaseId",
                        column: x => x.TestcaseId,
                        principalTable: "PolygonTestcases",
                        principalColumn: "TestcaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "ShortName" },
                values: new object[,]
                {
                    { -16, "c8259cc1-f159-cbf3-9348-ee1d3967d3ac", "Verified Student", "Student", "STUDENT", "student" },
                    { -32, "d68c9040-7762-ab0b-06eb-19ce1b5a5120", "Temporary Team Account", "TemporaryTeamAccount", "TEMPORARYTEAMACCOUNT", "temp_team" },
                    { -31, "8f8c37e1-a309-bd2d-6708-0519df89139b", "Contest Creator", "ContestCreator", "CONTESTCREATOR", "cont" },
                    { -30, "40100c40-6ca5-7bcb-48bc-41f2a939cbee", "CDS API user", "CDS", "CDS", "cds_api" },
                    { -11, "f25ae969-433c-3f4a-04ca-7ec12d2583cc", "Problem Provider", "ProblemCreator", "PROBLEMCREATOR", "prob" },
                    { -10, "44315c39-534d-ec0c-61f0-c0a5ed981cd9", "(Internal/System) Judgehost", "Judgehost", "JUDGEHOST", "judgehost" },
                    { -2, "f1722fb1-cd10-256b-48bb-71afd116ae66", "Blocked User", "Blocked", "BLOCKED", "blocked" },
                    { -1, "9805fda4-f300-ff78-a6d8-faf0d8e418fd", "Administrative User", "Administrator", "ADMINISTRATOR", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Name", "Category", "Description", "DisplayPriority", "Public", "Type", "Value" },
                values: new object[,]
                {
                    { "enable_register", "Identity", "Whether to allow user self registration.", 0, true, "bool", "true" },
                    { "diskspace_error", "Judging", "Minimum free disk space (in kB) on judgehosts.", 7, true, "int", "1048576" },
                    { "output_storage_limit", "Judging", "Maximum size of error/system output stored in the database (in bytes); use \"-1\" to disable any limits.", 6, true, "int", "60000" },
                    { "timelimit_overshoot", "Judging", "Time that submissions are kept running beyond timelimit before being killed. Specify as \"Xs\" for X seconds, \"Y%\" as percentage, or a combination of both separated by one of \"+|&\" for the sum, maximum, or minimum of both.", 5, true, "string", "\"1s|10%\"" },
                    { "script_filesize_limit", "Judging", "Maximum filesize (in kB) compile/compare scripts may write. Submission will fail with compiler-error when trying to write more, so this should be greater than any *intermediate or final* result written by compilers.", 4, true, "int", "540672" },
                    { "script_memory_limit", "Judging", "Maximum memory usage (in kB) by compile/compare scripts. This is a safeguard against malicious code and buggy script, so a reasonable but large amount should do.", 3, true, "int", "2097152" },
                    { "script_timelimit", "Judging", "Maximum seconds available for compile/compare scripts. This is a safeguard against malicious code and buggy scripts, so a reasonable but large amount should do.", 2, true, "int", "30" },
                    { "process_limit", "Judging", "Maximum number of processes that the submission is allowed to start (including shell and possibly interpreters).", 1, true, "int", "64" },
                    { "update_judging_seconds", "Judging", "Post updates to a judging every X seconds. Set to 0 to update after each judging_run.", 8, true, "int", "0" }
                });

            migrationBuilder.InsertData(
                table: "TenantAffiliation",
                columns: new[] { "Id", "Abbreviation", "CountryCode", "EmailSuffix", "Name" },
                values: new object[] { -1, "null", "CHN", null, "(none)" });

            migrationBuilder.InsertData(
                table: "TenantCategory",
                columns: new[] { "Id", "Color", "IsPublic", "Name", "SortOrder" },
                values: new object[,]
                {
                    { -5, "#ff99cc", true, "Organisation", 1 },
                    { -1, "#ff2bea", false, "System", 9 },
                    { -2, "#33cc44", true, "Self-Registered", 8 },
                    { -3, "#ffffff", true, "Participants", 0 },
                    { -4, "#ffcc33", true, "Observers", 0 },
                    { -6, "#96d5ff", true, "Companies", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentId",
                table: "AspNetUsers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditlogs_DataType",
                table: "Auditlogs",
                column: "DataType");

            migrationBuilder.CreateIndex(
                name: "IX_ContestBalloons_SubmissionId",
                table: "ContestBalloons",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestClarifications_ProblemId",
                table: "ContestClarifications",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestClarifications_ResponseToId",
                table: "ContestClarifications",
                column: "ResponseToId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestClarifications_ContestId_Recipient",
                table: "ContestClarifications",
                columns: new[] { "ContestId", "Recipient" });

            migrationBuilder.CreateIndex(
                name: "IX_ContestClarifications_ContestId_Sender",
                table: "ContestClarifications",
                columns: new[] { "ContestId", "Sender" });

            migrationBuilder.CreateIndex(
                name: "IX_ContestEvents_ContestId",
                table: "ContestEvents",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestEvents_EventTime",
                table: "ContestEvents",
                column: "EventTime");

            migrationBuilder.CreateIndex(
                name: "IX_ContestJury_UserId",
                table: "ContestJury",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestMembers_UserId",
                table: "ContestMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestMembers_ContestId_UserId",
                table: "ContestMembers",
                columns: new[] { "ContestId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContestPrintings_ContestId",
                table: "ContestPrintings",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestPrintings_UserId",
                table: "ContestPrintings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestProblems_ProblemId",
                table: "ContestProblems",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestProblems_ContestId_ShortName",
                table: "ContestProblems",
                columns: new[] { "ContestId", "ShortName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContestTeams_AffiliationId",
                table: "ContestTeams",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTeams_CategoryId",
                table: "ContestTeams",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTeams_ContestId_Status",
                table: "ContestTeams",
                columns: new[] { "ContestId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_ContestTenants_AffiliationId",
                table: "ContestTenants",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlagiarismReports_SetId_SubmissionB",
                table: "PlagiarismReports",
                columns: new[] { "SetId", "SubmissionB" });

            migrationBuilder.CreateIndex(
                name: "IX_PlagiarismSets_ContestId",
                table: "PlagiarismSets",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_PlagiarismSets_UserId",
                table: "PlagiarismSets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonAuthors_ProblemId",
                table: "PolygonAuthors",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonAuthors_UserId",
                table: "PolygonAuthors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonErrors_Status",
                table: "PolygonErrors",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonJudgingRuns_JudgingId",
                table: "PolygonJudgingRuns",
                column: "JudgingId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonJudgingRuns_TestcaseId",
                table: "PolygonJudgingRuns",
                column: "TestcaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonJudgings_PreviousJudgingId",
                table: "PolygonJudgings",
                column: "PreviousJudgingId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonJudgings_RejudgingId",
                table: "PolygonJudgings",
                column: "RejudgingId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonJudgings_Server",
                table: "PolygonJudgings",
                column: "Server");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonJudgings_Status",
                table: "PolygonJudgings",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonJudgings_SubmissionId",
                table: "PolygonJudgings",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonLanguages_CompileScript",
                table: "PolygonLanguages",
                column: "CompileScript");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonProblems_CompareScript",
                table: "PolygonProblems",
                column: "CompareScript");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonProblems_RunScript",
                table: "PolygonProblems",
                column: "RunScript");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonRejudgings_ContestId",
                table: "PolygonRejudgings",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonRejudgings_IssuedBy",
                table: "PolygonRejudgings",
                column: "IssuedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonRejudgings_OperatedBy",
                table: "PolygonRejudgings",
                column: "OperatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonStatistics_ContestId",
                table: "PolygonStatistics",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonStatistics_ProblemId",
                table: "PolygonStatistics",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonStatistics_ContestId_ProblemId",
                table: "PolygonStatistics",
                columns: new[] { "ContestId", "ProblemId" });

            migrationBuilder.CreateIndex(
                name: "IX_PolygonStatistics_ContestId_TeamId",
                table: "PolygonStatistics",
                columns: new[] { "ContestId", "TeamId" });

            migrationBuilder.CreateIndex(
                name: "IX_PolygonSubmissions_ContestId",
                table: "PolygonSubmissions",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonSubmissions_Language",
                table: "PolygonSubmissions",
                column: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonSubmissions_ProblemId",
                table: "PolygonSubmissions",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonSubmissions_RejudgingId",
                table: "PolygonSubmissions",
                column: "RejudgingId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonSubmissions_ContestId_TeamId",
                table: "PolygonSubmissions",
                columns: new[] { "ContestId", "TeamId" });

            migrationBuilder.CreateIndex(
                name: "IX_PolygonTestcases_ProblemId",
                table: "PolygonTestcases",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonTestcases_ProblemId_Rank",
                table: "PolygonTestcases",
                columns: new[] { "ProblemId", "Rank" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenantAffiliation_Abbreviation",
                table: "TenantAffiliation",
                column: "Abbreviation");

            migrationBuilder.CreateIndex(
                name: "IX_TenantCategory_IsPublic",
                table: "TenantCategory",
                column: "IsPublic");

            migrationBuilder.CreateIndex(
                name: "IX_TenantCategory_SortOrder",
                table: "TenantCategory",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_TenantClassStudents_ClassId",
                table: "TenantClassStudents",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantStudents_AffiliationId",
                table: "TenantStudents",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantTeachingClasses_AffiliationId",
                table: "TenantTeachingClasses",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantTeachingClasses_UserId",
                table: "TenantTeachingClasses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Auditlogs");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "ContestBalloons");

            migrationBuilder.DropTable(
                name: "ContestClarifications");

            migrationBuilder.DropTable(
                name: "ContestEvents");

            migrationBuilder.DropTable(
                name: "ContestJury");

            migrationBuilder.DropTable(
                name: "ContestMembers");

            migrationBuilder.DropTable(
                name: "ContestPrintings");

            migrationBuilder.DropTable(
                name: "ContestProblems");

            migrationBuilder.DropTable(
                name: "ContestRankCache");

            migrationBuilder.DropTable(
                name: "ContestScoreCache");

            migrationBuilder.DropTable(
                name: "ContestTenants");

            migrationBuilder.DropTable(
                name: "PlagiarismFiles");

            migrationBuilder.DropTable(
                name: "PlagiarismReports");

            migrationBuilder.DropTable(
                name: "PolygonAuthors");

            migrationBuilder.DropTable(
                name: "PolygonErrors");

            migrationBuilder.DropTable(
                name: "PolygonJudgingRuns");

            migrationBuilder.DropTable(
                name: "PolygonStatistics");

            migrationBuilder.DropTable(
                name: "TenantClassStudents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ContestTeams");

            migrationBuilder.DropTable(
                name: "PlagiarismSubmissions");

            migrationBuilder.DropTable(
                name: "PolygonJudgings");

            migrationBuilder.DropTable(
                name: "PolygonTestcases");

            migrationBuilder.DropTable(
                name: "TenantTeachingClasses");

            migrationBuilder.DropTable(
                name: "TenantCategory");

            migrationBuilder.DropTable(
                name: "PlagiarismSets");

            migrationBuilder.DropTable(
                name: "PolygonJudgehosts");

            migrationBuilder.DropTable(
                name: "PolygonSubmissions");

            migrationBuilder.DropTable(
                name: "PolygonLanguages");

            migrationBuilder.DropTable(
                name: "PolygonProblems");

            migrationBuilder.DropTable(
                name: "PolygonRejudgings");

            migrationBuilder.DropTable(
                name: "PolygonExecutables");

            migrationBuilder.DropTable(
                name: "Contests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TenantStudents");

            migrationBuilder.DropTable(
                name: "TenantAffiliation");
        }
    }
}
