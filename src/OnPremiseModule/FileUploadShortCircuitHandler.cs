using MediatR;
using Microsoft.Extensions.Options;
using Polygon;
using Polygon.Events;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SatelliteSite.OnPremiseModule
{
    public class FileUploadShortCircuitHandler :
        INotificationHandler<JudgingPrepublishEvent>,
        INotificationHandler<JudgingRunEmittedEvent>
    {
        private readonly bool _enabled;
        private readonly string _endpointName;
        private readonly PolygonPhysicalOptions _options;

        public FileUploadShortCircuitHandler(
            IOptions<FileUploadShortCircuitOptions> options,
            IOptions<PolygonPhysicalOptions> options1)
        {
            _enabled = options.Value.Enabled;
            _endpointName = options.Value.EndpointName;
            _options = options1.Value;
        }

        public Task Handle(
            JudgingPrepublishEvent notification,
            CancellationToken cancellationToken)
        {
            if (_enabled) notification.NextJudging.SendOutputBack = false;
            return Task.CompletedTask;
        }

        public Task Handle(
            JudgingRunEmittedEvent notification,
            CancellationToken cancellationToken)
        {
            if (!_enabled) return Task.CompletedTask;

            var baseDir = Path.Combine(_options.JudgingDirectory, $"j{notification.Judging.Id}");
            if (!Directory.Exists(baseDir)) Directory.CreateDirectory(baseDir);

            var srcDir = Path.Combine(
                "/opt/domjudge/judgehost/judgings",
                notification.Judging.Server,
                "endpoint-" + _endpointName,
                (notification.ContestId ?? 0).ToString(),
                notification.Judging.SubmissionId.ToString(),
                notification.Judging.Id.ToString());

            for (int i = 0; i < notification.Runs.Count; i++)
            {
                var run = notification.Runs[i];
                var outFile = Path.Combine(baseDir, $"r{run.Id}.out");
                var errFile = Path.Combine(baseDir, $"r{run.Id}.err");

                var tcDir = Path.Combine(srcDir, $"testcase{notification.RankOfFirst + i:d3}");
                var outSrc = Path.Combine(tcDir, "program.out");
                var errSrc = Path.Combine(tcDir, "program.err");

                if (File.Exists(outSrc) && !File.Exists(outFile))
                {
                    File.Move(outSrc, outFile);
                }

                if (File.Exists(errSrc) && !File.Exists(errFile))
                {
                    File.Move(errSrc, errFile);
                }
            }

            return Task.CompletedTask;
        }
    }
}
