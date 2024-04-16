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

        public async Task<IActionResult> All([FromQuery] AllEventsQueryModel query)
        {
            var model = await eventService.AllSortingAsync(query.SearchTerm, query.Sorting, query.CurrentPage, query.EventsPerPage);

            query.TotalEventsCount = model.TotalEventCount;
            query.Events = model.Events;

            return View(query);
        }

        public async Task<IActionResult> DetailsGame(int Id)
        {
            var model = await footballGameService.GetFootballDetailsAsync(Id);

            if (model == null) 
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
