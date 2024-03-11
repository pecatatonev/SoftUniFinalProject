using Microsoft.AspNetCore.Mvc;

namespace SoftUniFinalProject.Controllers
{
    public class AttendanceController : Controller
    {
        public IActionResult MyEvents()
        {
            return View();
        }

        public IActionResult Join()
        {
            return View();
        }

        public IActionResult Leave()
        {
            return View();
        }
    }
}
