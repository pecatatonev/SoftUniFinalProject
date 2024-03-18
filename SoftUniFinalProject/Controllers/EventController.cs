using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Contracts.Team;

namespace SoftUniFinalProject.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }

        public async Task<IActionResult> All()
        {
            var model = await eventService.AllEventsAsync();

            return View(model);
        }

        public IActionResult Details()
        {
            return View();
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
