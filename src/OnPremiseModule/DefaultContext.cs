using Ccs.Entities;
using Ccs.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Polygon.Entities;
using Polygon.Models;
using Polygon.Storages;
using SatelliteSite.IdentityModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tenant.Entities;

namespace SatelliteSite
{
    public class DefaultContext :
        IdentityDbContext<XylabUser, Role, int>,
        IPolygonDbContext,
        IContestDbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<Contest> Contests { get; set; }
        public virtual DbSet<ContestProblem> ContestProblems { get; set; }
        public virtual DbSet<Jury> ContestJuries { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Member> TeamMembers { get; set; }
        public virtual DbSet<Clarification> Clarifications { get; set; }
        public virtual DbSet<Balloon> Balloons { get; set; }
        public virtual DbSet<Event> ContestEvents { get; set; }
        public virtual DbSet<Printing> Printings { get; set; }
        public virtual DbSet<RankCache> RankCache { get; set; }
        public virtual DbSet<ScoreCache> ScoreCache { get; set; }
        public virtual DbSet<Submission> Submissions { get; set; }
        public virtual DbSet<Judging> Judgings { get; set; }
        public virtual DbSet<JudgingRun> JudgingRuns { get; set; }
        public virtual DbSet<Testcase> Testcases { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Affiliation> Affiliations { get; set; }
        public virtual DbSet<Executable> Executables { get; set; }
        public virtual DbSet<InternalError> InternalErrors { get; set; }
        public virtual DbSet<Judgehost> Judgehosts { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Problem> Problems { get; set; }
        public virtual DbSet<Rejudging> Rejudgings { get; set; }
        public virtual DbSet<SubmissionStatistics> SubmissionStatistics { get; set; }
        public virtual DbSet<ProblemAuthor> ProblemAuthors { get; set; }
        public virtual DbSet<Visibility> ContestTenants { get; set; }

        IQueryable<IUser> IContestDbContext.Users => Users;
        IQueryable<Submission> IContestDbContext.Submissions => Submissions;
        IQueryable<Problem> IContestDbContext.Problems => Problems;
        IQueryable<ProblemAuthor> IContestDbContext.ProblemAuthors => ProblemAuthors;
        IQueryable<Judging> IContestDbContext.Judgings => Judgings;
        IQueryable<JudgingRun> IContestDbContext.JudgingRuns => JudgingRuns;
        IQueryable<Testcase> IContestDbContext.Testcases => Testcases;
        IQueryable<Affiliation> IContestDbContext.Affiliations => Affiliations;
        IQueryable<Category> IContestDbContext.Categories => Categories;
        IQueryable<SubmissionStatistics> IContestDbContext.SubmissionStatistics => SubmissionStatistics;
    }
}
