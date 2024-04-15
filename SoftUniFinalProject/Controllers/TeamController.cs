using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Core.Services.EventService;
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllTeamsQueryModel query)
        {
            var model = await teamService.AllSortingAsync(query.SearchTerm, query.Sorting, query.CurrentPage, query.TeamsPerPage);

            query.TotalTeamsCount = model.TotalTeamsCount;
            query.Teams = model.Teams;

            return View(query);
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
    }
}
