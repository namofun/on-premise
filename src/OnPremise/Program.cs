using Ccs.Registration;
using Markdig;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SatelliteSite.IdentityModule.Entities;
using System;
using System.IO;

namespace SatelliteSite
{
    public class Program
    {
        public static IHost Current { get; private set; }

        public static void Main(string[] args)
        {
            Current = CreateHostBuilder(args).Build();
            Current.AutoMigrate<DefaultContext>();
            Current.MigratePolygonV1();
            Current.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .MarkDomain<Program>()
                .AddModule<TelemetryModule.TelemetryModule>()
                .AddModule<IdentityModule.IdentityModule<XylabUser, Role, DefaultContext>>()
                .AddModule<OnPremiseModule.OnPremiseModule>()
                .AddModule<GroupModule.GroupModule<DefaultContext>>()
                .AddModule<JobsModule.JobsModule<XylabUser, DefaultContext>>()
                .AddModule<StudentModule.StudentModule<XylabUser, Role, DefaultContext>>()
                .AddModule<PolygonModule.PolygonModule<Polygon.DefaultRole<DefaultContext, DefaultQueryCache>>>()
                .AddModule<ContestModule.ContestModule<Ccs.RelationalRole<XylabUser, Role, DefaultContext>>>()
                .AddModule<PlagModule.PlagModule<Plag.Backend.StorageBackendRole<DefaultContext>>>()
                .AddModule<ExperimentalModule.ExperimentalModule>()
                .AddDatabase<DefaultContext>((c, b) =>
                {
                    if (!string.IsNullOrEmpty(c.GetConnectionString("SqlServerDbConnection")))
                    {
                        b.UseSqlServer(
                            c.GetConnectionString("SqlServerDbConnection"),
                            b => b.UseBulk()
                                  .MigrationsAssembly("SatelliteSite.Migrations.SqlServer"));
                    }
                    else if (!string.IsNullOrEmpty(c.GetConnectionString("PostgresDbConnection")))
                    {
                        b.UseNpgsql(
                            c.GetConnectionString("PostgresDbConnection"),
                            b => b.UseBulk()
                                  .MigrationsAssembly("SatelliteSite.Migrations.Postgres"));
                    }
                    else
                    {
                        throw new InvalidOperationException(
                            "Please specify SqlServerDbConnection or PostgresDbConnection!");
                    }
                })
                .ConfigureSubstrateDefaults<DefaultContext>()
                .ConfigureServices((context, services) =>
                {
                    services.AddMarkdown();

                    services.AddDbModelSupplier<DefaultContext, Polygon.Storages.PolygonIdentityEntityConfiguration<XylabUser, DefaultContext>>();

                    services.ConfigurePolygonStorage(options =>
                    {
                        options.JudgingDirectory = Path.Combine(context.HostingEnvironment.ContentRootPath, "Runs");
                        options.ProblemDirectory = Path.Combine(context.HostingEnvironment.ContentRootPath, "Problems");
                    });

                    services.AddContestRegistrationTenant();

                    services.Configure<ContestModule.Routing.MinimalSiteOptions>(options =>
                    {
                        options.Keyword = context.Configuration.GetConnectionString("ContestKeyword");
                        options.RealIpHeaderName = "Jluds-Cdn-Real-Ip";
                    });

                    services.Configure<Ccs.Connector.Jobs.ExportPdfOptions>(options =>
                    {
                        options.Url = context.Configuration.GetConnectionString("PdfService");
                    });

                    services.Configure<OnPremiseModule.FileUploadShortCircuitOptions>(options =>
                    {
                        options.Enabled = context.Configuration.GetValue<bool?>("FileUploadShortCircuit") ?? false;
                    });

                    services.Configure<Services.AuthMessageSenderOptions>(context.Configuration.GetSection("Mailing"));

                    if (!string.IsNullOrEmpty(context.GetConnectionString("SqlServerDbConnection")))
                    {
                        services.AddSingleton<IDurationCalculator, SqlServerTimeDiff>();
                    }
                    else if (!string.IsNullOrEmpty(context.GetConnectionString("PostgresDbConnection")))
                    {
                        services.AddSingleton<IDurationCalculator, PostgresTimeDiff>();
                    }
                    else
                    {
                        throw new InvalidOperationException(
                            "Please specify SqlServerDbConnection or PostgresDbConnection!");
                    }
                });
    }
}
