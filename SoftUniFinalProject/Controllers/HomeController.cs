using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Contracts.Home;
using SoftUniFinalProject.Core.Models.Home;

namespace SoftUniFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IEventService eventService;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> _logger, IEventService _eventService, IHomeService _homeService)
        {
            logger = _logger;
            eventService = _eventService;
            homeService = _homeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            var model = new ContactFormViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await homeService.SendEmailAsync(model.Email, model.Subject, model.Message);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }
            else if (statusCode == 500)
            {
                return View("Error500");
            }

            return View();
        }
    }
}