using Ccs.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Polygon.Storages;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace SatelliteSite.OnPremiseModule.Controllers
{
    [Area("Xylab")]
    [SupportStatusCodePage]
    [Route("/[action]")]
    public class HomeController : ViewControllerBase
    {
        public static string ProgramVersion { get; }
            = typeof(HomeController).Assembly
                .GetCustomAttribute<GitVersionAttribute>()?
                .Version?.Substring(0, 7) ?? "unknown";


        [HttpGet]
        [HttpGet("/")]
        public async Task<IActionResult> Index(
            [FromServices] IContestRepository2 contests,
            [FromServices] IMemoryCache memoryCache,
            [FromQuery] int page = 1)
        {
            if (page < 1) return BadRequest();
            var model = await contests.ListAsync(User, page: page, limit: 20);

            ViewBag.Health = await memoryCache.GetOrCreateAsync("frontend_judgehosts_and_loads", async entry =>
            {
                var judgehosts = HttpContext.RequestServices.GetRequiredService<IJudgehostStore>();
                var load = await judgehosts.LoadAsync();
                var hosts = await judgehosts.ListAsync();
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
                return (load, hosts, DateTimeOffset.Now);
            });

            return View(model);
        }
    }
}
