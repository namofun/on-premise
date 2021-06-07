using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SatelliteSite
{
    public class PostgresTimeDiff : IDurationCalculator
    {
        public Expression<Func<DateTimeOffset, DateTimeOffset, double>> Expression { get; }
            = (start, end) => ExtractEpochFromAge(end, start);

        public static double ExtractEpochFromAge(DateTimeOffset end, DateTimeOffset start)
            => (end - start).TotalSeconds;
    }

    public class PostgresTimeDiffModel<TContext>
        : IDbModelSupplier<TContext>
        where TContext : DbContext
    {
        private static SqlFunctionExpression Builtin(
            string name,
            Type clrType,
            RelationalTypeMapping dbType,
            params SqlExpression[] arguments)
            => new SqlFunctionExpression(
                instance: null,
                schema: null,
                name: name,
                niladic: false,
                arguments: arguments,
                builtIn: true,
                type: clrType,
                typeMapping: dbType);

        public void Configure(ModelBuilder builder, TContext context)
        {
            // EXTRACT(EPOCH FROM INTERVAL '5 days 3 hours')
            builder.HasDbFunction(typeof(PostgresTimeDiff).GetMethod("ExtractEpochFromAge"), func =>
            {
                func.HasParameter("end")
                    .HasStoreType("timestamp with time zone");

                func.HasParameter("start")
                    .HasStoreType("timestamp with time zone");

                func.HasStoreType("double precision");

                func.HasTranslation(exp =>
                    Builtin("EXTRACT", typeof(double), new DoubleTypeMapping("double precision"),
                        Builtin("EPOCH FROM AGE", typeof(TimeSpan), new TimeSpanTypeMapping("INTERVAL"),
                            exp.ToArray())));
            });
        }
    }
}
