using System;
using System.Linq.Expressions;

namespace SatelliteSite
{
    public interface IDurationCalculator
    {
        public Expression<Func<DateTimeOffset, DateTimeOffset, double>> Expression { get; }
    }
}
