using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Team;

namespace SoftUniFinalProject.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        private readonly ISponsorService sponsorService;

        public TeamController(ITeamService _teamService, ISponsorService _sponsorService)
        {
            teamService = _teamService;
            sponsorService = _sponsorService;
        }
        public async Task<IActionResult> All()
        {
            var model = await teamService.AllTeams();

            return View(model);
        }

        public IActionResult Details()
        {
            return View();
        }

        public async Task<IActionResult> Sponsors()
        {
            var model = await sponsorService.SponsorsAll();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
