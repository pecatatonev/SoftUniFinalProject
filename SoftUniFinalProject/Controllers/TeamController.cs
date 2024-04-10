using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Team;
using System.Net.WebSockets;
using System.Transactions;

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
            var model = await teamService.AllTeamsAsync();

            return View(model);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var model = await teamService.GetTeamDetailsAsync(Id);

            return View(model);
        }

        public async Task<IActionResult> Sponsors(int Id)
        {
            var model = await sponsorService.SponsorsByTeamAsync(Id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //Only Admin can create team later check
            var model = new AddTeamViewModel()
            {
                Sponsors = await sponsorService.AllSponsorsToAddAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddTeamViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                model.Sponsors = await sponsorService.AllSponsorsToAddAsync();

                return View(model);
            }

            int teamId = await teamService.CreateAsync(model);

            return RedirectToAction(nameof(Details), new { id = teamId});
        }
    }
}
