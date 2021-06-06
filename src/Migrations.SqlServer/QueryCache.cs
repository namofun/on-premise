using Microsoft.EntityFrameworkCore;
using Polygon.Entities;
using Polygon.Models;
using Polygon.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SatelliteSite
{
    public class SqlServerQueryCache : QueryCacheBase<DefaultContext>
    {
        public override async Task<IEnumerable<(int UserId, string UserName, AuthorLevel Level)>> FetchPermittedUserAsync(DefaultContext context, int probid)
        {
            var query =
                from s in context.ProblemAuthors
                where s.ProblemId == probid
                join u in context.Users on s.UserId equals u.Id
                select new { u.Id, u.UserName, s.Level };
            return (await query.ToListAsync()).Select(a => (a.Id, a.UserName, a.Level));
        }

        public override Task<List<SolutionAuthor>> FetchSolutionAuthorAsync(DefaultContext context, Expression<Func<Submission, bool>> predicate)
        {
            var query =
                from s in context.Submissions.WhereIf(predicate != null, predicate)
                join u in context.Users on new { s.ContestId, s.TeamId } equals new { ContestId = 0, TeamId = u.Id }
                into uu
                from u in uu.DefaultIfEmpty()
                join t in context.Teams on new { s.ContestId, s.TeamId } equals new { t.ContestId, t.TeamId }
                into tt
                from t in tt.DefaultIfEmpty()
                select new SolutionAuthor(s.Id, s.ContestId, s.TeamId, u.UserName, t.TeamName);
            return query.ToListAsync();
        }

        protected override Expression<Func<DateTimeOffset, DateTimeOffset, double>> CalculateDuration { get; }
            = (start, end) => EF.Functions.DateDiffMillisecond(start, end) / 1000.0;
    }
}
