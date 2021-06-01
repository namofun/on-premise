using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace SatelliteSite.ExperimentalModule
{
    public class ExperimentalModule : AbstractModule
    {
        public override string Area => "Xylab";

        public override void Initialize()
        {
        }

        public override void RegisterMenu(IMenuContributor menus)
        {
            menus.Submenu(MenuNameDefaults.UserDropdown, menu =>
            {
                menu.HasEntry(100)
                    .HasTitle("fas fa-feather", "Dashboard (Preview)")
                    .HasLink("Dashboard", "TeachingCenter", "Index")
                    .WithMetadata("RequiredPolicy", "TenantAdmin");
            });

            menus.Menu("Menu_TeachingCenter", menu =>
            {
                menu.HasEntry(0)
                    .HasTitle(string.Empty, "Teaching Center")
                    .HasLink("Dashboard", "TeachingCenter", "Index")
                    .ActiveWhenAction("Index");

                menu.HasEntry(100)
                    .HasTitle(string.Empty, "Organization")
                    .HasLink("Dashboard", "TeachingCenter", "Organization")
                    .ActiveWhenAction("Organization");

                menu.HasEntry(200)
                    .HasTitle(string.Empty, "Export Collection")
                    .HasLink("Dashboard", "TeachingCenter", "BackgroundJobs")
                    .ActiveWhenAction("BackgroundJobs");
            });
        }

        public override void RegisterEndpoints(IEndpointBuilder endpoints)
        {
            endpoints.MapControllers();
        }
    }
}
