using SatelliteSite.IdentityModule.Entities;
using Tenant.Entities;

namespace SatelliteSite
{
    public class XylabUser : User, IUserWithStudent
    {
        public string StudentId { get; set; }

        public string StudentEmail { get; set; }

        public bool StudentVerified { get; set; }
    }
}
