using System;
using System.Linq.Expressions;

namespace SatelliteSite
{
    public class PostgresTimeDiff : IDurationCalculator
    {
        public PostgresTimeDiff()
        {
            throw new NotImplementedException();
        }

        public Expression<Func<DateTimeOffset, DateTimeOffset, double>> Expression { get; }
            = (start, end) => (end - start).TotalSeconds;
    }
}
