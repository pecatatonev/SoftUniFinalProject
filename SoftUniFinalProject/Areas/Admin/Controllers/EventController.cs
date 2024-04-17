using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Extensions;
using SoftUniFinalProject.Infrastructure.Constants;
using System.Globalization;

namespace SoftUniFinalProject.Areas.Admin.Controllers
{
    public class EventController : AdminBaseController
    {
        private readonly IEventService eventService;
        private readonly IFootballGameService footballGameService;
        private readonly ITeamService teamService;

        public EventController(IEventService _eventService, IFootballGameService _footballGameService, ITeamService _teamService)
        {
            eventService = _eventService;
            footballGameService = _footballGameService;
            teamService = _teamService;
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

            if (result == 500)
            {
                return StatusCode(500);
            }
            if (!ModelState.IsValid)
            {
                model.FootballGames = await footballGameService.GetAllFootballGamesAsync();

                return View(model);
            }

            return RedirectToAction("All", "Event", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if ((await eventService.ExistsAsync(Id)) == false)
            {
                return RedirectToAction("All", "Event", new { area = "" });
            }

            var eventModel = await eventService.EventByIdAsync(Id);

            var model = new AddEventViewModel()
            {
                Id = eventModel.Id,
                Description = eventModel.Description,
                Location = eventModel.Location,
                Name = eventModel.Name,
                StartOn = eventModel.StartOn.ToString(DataConstants.DateTimeFormat, CultureInfo.InvariantCulture),
                FootballGameId = eventModel.FootballGameId,
                FootballGames = await footballGameService.GetAllFootballGamesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, AddEventViewModel model)
        {
            if (Id != model.Id)
            {
                return RedirectToAction("All", "Event", new { area = "" });
            }

            if (await eventService.ExistsAsync(model.Id) == false)
            {
                ModelState.AddModelError("", "Event does not exist");
                model.FootballGames = await footballGameService.GetAllFootballGamesAsync();

                return View(model);
            }

            if ((await footballGameService.FootballGameExistAsync(model.FootballGameId)) == false)
            {
                ModelState.AddModelError(nameof(model.FootballGameId), "Football Game doesn't exist");
            }

            if (await eventService.EditAsync(model.Id, model) == -1)
            {
                ModelState.AddModelError(nameof(model.StartOn), $"Invalid Date! Format must be:{DataConstants.DateTimeFormat}");

                model.FootballGames = await footballGameService.GetAllFootballGamesAsync();
                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.FootballGames = await footballGameService.GetAllFootballGamesAsync();

                return View(model);
            }

            return RedirectToAction("All", "Event", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if ((await eventService.ExistsAsync(Id) == false))
            {
                return RedirectToAction("All", "Event", new { area = "" });
            }

            var eventToDelete = await eventService.EventByIdAsync(Id);
            var model = new EventDeleteViewModel()
            {
                Id = eventToDelete.Id,
                Location = eventToDelete.Location,
                Name = eventToDelete.Name,
                StartOn = eventToDelete.StartOn.ToString(DataConstants.DateTimeFormat, CultureInfo.InvariantCulture),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id, EventDeleteViewModel model)
        {
            if ((await eventService.ExistsAsync(Id) == false))
            {
                return RedirectToAction("All", "Event", new { area = "" });
            }

            await eventService.DeleteAsync(model.Id);

            return RedirectToAction("All", "Event", new { area = "" });
        }


        [HttpGet]
        public async Task<IActionResult> AllFootballGames()
        {
            var footballGames = await footballGameService.GetAllFootballGamesInAdminAsync();
            return View(footballGames);
        }
        [HttpGet]
        public async Task<IActionResult> CrateFootballGame()
        {
            var model = new AddFootballGameViewModel()
            {
                AwayTeams = await teamService.GetAllTeamsAsync(),
                HomeTeams = await teamService.GetAllTeamsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CrateFootballGame(AddFootballGameViewModel model)
        {
            var result = await footballGameService.CreateAsync(model);

            if (result == -1)
            {
                ModelState.AddModelError(nameof(model.StartGame), $"Invalid Date! Format must be: {DataConstants.DateTimeFormat}");
            }

            if (result == -2)
            {
                ModelState.AddModelError(nameof(model.Id), $"The Home and Away Team cannot be the same!");
            }

            if (!ModelState.IsValid)
            {
                model.AwayTeams = await teamService.GetAllTeamsAsync();
                model.HomeTeams = await teamService.GetAllTeamsAsync();

                return View(model);
            }

            return RedirectToAction("All", "Event", new { area = "" });
        }

        public async Task<IActionResult> CheckDate()
        {
            var deletedFootballGames = await footballGameService.DeleteFinishedGamesAsync();

            if (deletedFootballGames == 0) 
            {
                ModelState.AddModelError(nameof(deletedFootballGames), $"There is no football games at the momment!");
            }
            return RedirectToAction(nameof(AllFootballGames));
        }
    }
}
