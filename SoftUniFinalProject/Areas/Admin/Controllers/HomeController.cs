using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SoftUniFinalProject.Core.Constants.RoleConstants;

namespace SoftUniFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdministratorRole)]
    public class HomeController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
