using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace SatelliteSite
{
    public class SqlServerTimeDiff : IDurationCalculator
    {
        public Expression<Func<DateTimeOffset, DateTimeOffset, double>> Expression { get; }
            = (start, end) => EF.Functions.DateDiffMillisecond(start, end) / 1000.0;
    }
}
