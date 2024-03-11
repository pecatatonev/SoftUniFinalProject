using Microsoft.AspNetCore.Mvc;

namespace SoftUniFinalProject.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
