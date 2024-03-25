using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Models;
using System.Diagnostics;

namespace SoftUniFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IEventService eventService;

        public HomeController(ILogger<HomeController> _logger, IEventService _eventService)
        {
            logger = _logger;
            eventService = _eventService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await eventService.LastThreeEvents();

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}