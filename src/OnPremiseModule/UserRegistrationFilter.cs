using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SatelliteSite.OnPremiseModule
{
    public class UserRegistrationFilter : INotificationHandler<RegisterNotification>
    {
        public Task Handle(RegisterNotification notification, CancellationToken cancellationToken)
        {
            if (notification.Username.StartsWith("team", StringComparison.OrdinalIgnoreCase))
            {
                notification.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
