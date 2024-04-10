using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Core.Services.TeamService;
using SoftUniFinalProject.Extensions;
using SoftUniFinalProject.Infrastructure.Constants;
using System.Globalization;
using System.Security.Claims;

namespace SoftUniFinalProject.Controllers
{
    [Authorize]
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
            
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if ((await eventService.ExistsAsync(Id)) == false) 
            {
                return RedirectToAction(nameof(All));
            }

            var userId = User.Id();
            if (await eventService.SameOrganiserAsync(Id, userId) == false)
            {
                return RedirectToAction(nameof(All));
            };

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
                return RedirectToAction(nameof(All));
            }

            if (await eventService.ExistsAsync(model.Id) == false)
            {
                ModelState.AddModelError("", "Event does not exist");
                model.FootballGames = await footballGameService.GetAllFootballGamesAsync();

                return View(model);
            }

            if (await eventService.SameOrganiserAsync(model.Id, User.Id()) == false)
            {
                return RedirectToAction(nameof(All));
            };

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

           
            
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if ((await eventService.ExistsAsync(Id) == false))
            {
                return RedirectToAction(nameof(All));
            }

            if (await eventService.SameOrganiserAsync(Id, User.Id()) == false)
            {
                return RedirectToAction(nameof(All));
            };

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
                return RedirectToAction(nameof(All));
            }

            //later admin or organiser
            if (await eventService.SameOrganiserAsync(Id, User.Id()) == false)
            {
                return RedirectToAction(nameof(All));
            };

            await eventService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

        //maybe search action
    }
}
