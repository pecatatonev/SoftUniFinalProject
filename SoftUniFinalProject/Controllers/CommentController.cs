using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Comment;
using SoftUniFinalProject.Core.Models.Comment;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Services.EventService;
using SoftUniFinalProject.Extensions;
using SoftUniFinalProject.Infrastructure.Constants;

namespace SoftUniFinalProject.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }
        public async Task<IActionResult> All(int Id)
        {
            //check if eventId exist later
            ViewBag.Id = Id;
            var model = await commentService.GetAllCommentsForEventAsync(Id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CommentToCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentToCreateViewModel model, int eventId)
        {
            
            var userId = User.Id();
            var result = await commentService.CreateCommentAsync(model, userId, eventId);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction(nameof(All), new { Id = eventId });
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
