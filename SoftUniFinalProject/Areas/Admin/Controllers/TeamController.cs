using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Team;

namespace SoftUniFinalProject.Areas.Admin.Controllers
{
    public class TeamController : AdminBaseController
    {
        private readonly ITeamService teamService;
        private readonly ISponsorService sponsorService;

        public TeamController(ITeamService _teamService, ISponsorService _sponsorService)
        {
            teamService = _teamService;
            sponsorService = _sponsorService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
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

            return RedirectToAction("Details", "Team",  new { area = "", id = teamId });
        }

        [HttpGet]
        public async Task<IActionResult> AllSponsors()
        {
               var sponsors = await sponsorService.AllSponsorsAsync();

            return View(sponsors);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSponsor()
        {
            var model = new CreateSponsorViewModel()
            {
                Teams = await teamService.GetAllTeamsForSponsorAsync(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSponsor(CreateSponsorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Teams = await teamService.GetAllTeamsForSponsorAsync();

                return View(model);
            }

            int teamId = await sponsorService.CreateAsync(model);

            return RedirectToAction(nameof(AllSponsors));
        }
    }
    
}
