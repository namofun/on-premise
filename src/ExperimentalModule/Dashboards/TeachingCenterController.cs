using Ccs.Services;
using Jobs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polygon.Entities;
using Polygon.Storages;
using System;
using System.Threading.Tasks;
using Tenant.Services;

namespace SatelliteSite.ExperimentalModule.Dashboards
{
    [Area("Dashboard")]
    [Authorize(Policy = "TenantAdmin")]
    [Route("/[area]/[controller]")]
    public class TeachingCenterController : StudentModule.Dashboards.TenantControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index(
            [FromServices] IContestRepository2 contests,
            [FromServices] IProblemStore problems,
            [FromServices] IStudentStore students)
        {
            var uid = int.Parse(User.GetUserId());

            ViewData["Contests"] = await contests.ListAsync(User, limit: 5);
            ViewData["Problems"] = await problems.ListAsync(1, 5, User, ascending: false, leastLevel: AuthorLevel.Creator);
            ViewData["Classes"] = await students.ListClassesAsync(Affiliation, 1, 5, uid);
            ViewData["ActiveAction"] = "Teacher";
            return View();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> Organization(
            [FromServices] IStudentStore store)
        {
            ViewBag.Administrators = await store.GetAdministratorsAsync(Affiliation);
            ViewBag.UserRoles = await store.GetAdministratorRolesAsync(Affiliation);
            ViewBag.VerifyCodes = await store.GetVerifyCodesAsync(Affiliation, validOnly: true);
            return View(Affiliation);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> BackgroundJobs(
            [FromServices] IJobManager manager,
            [FromQuery] int page = 1)
        {
            if (page <= 0) return BadRequest();
            int owner = int.Parse(User.GetUserId());
            return View(await manager.GetJobsAsync(owner, page));
        }
    }
}
