using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Core.Services.TeamService;
using SoftUniFinalProject.Extensions;
using SoftUniFinalProject.Infrastructure.Constants;
using System.Security.Claims;

namespace SoftUniFinalProject.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly IFootballGameService footballGameService;

        public EventController(IEventService _eventService, IFootballGameService _footballGameService)
        {
            eventService = _eventService;
            footballGameService = _footballGameService;
        }

        public async Task<IActionResult> All()
        {
            var model = await eventService.AllEventsAsync();

            return View(model);
        }

        public async Task<IActionResult> DetailsGame(int Id)
        {
            var model = await footballGameService.GetFootballDetailsAsync(Id);

            if (model == null) 
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new AddEventViewModel()
            {
                FootballGames = await footballGameService.GetAllFootballGamesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEventViewModel model)
        {
            if ((await footballGameService.FootballGameExistAsync(model.FootballGameId)) == false)
            {
                ModelState.AddModelError(nameof(model.FootballGameId), "Football Game doesn't exist");
            }
            var userId = User.Id();
            var result = await eventService.CreateAsync(model, userId);

            if (result == -1)
            {
                ModelState.AddModelError(nameof(model.StartOn), $"Invalid Date! Format must be:{DataConstants.DateTimeFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.FootballGames = await footballGameService.GetAllFootballGamesAsync();

                return View(model);
            }

            return RedirectToAction(nameof(DetailsGame), new { Id = result });
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        //maybe search action
    }
}
