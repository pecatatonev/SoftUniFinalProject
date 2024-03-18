using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Contracts.Team;

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

        public IActionResult Create()
        {
            return View();
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
