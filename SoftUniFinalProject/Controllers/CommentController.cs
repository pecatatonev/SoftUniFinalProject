using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftUniFinalProject.Core.Contracts.Comment;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Models.Comment;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Services.EventService;
using SoftUniFinalProject.Extensions;
using SoftUniFinalProject.Infrastructure.Constants;
using System.Globalization;

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
            await commentService.CreateCommentAsync(model, userId, eventId);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction(nameof(All), new { Id = eventId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if ((await commentService.ExistsAsync(Id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = User.Id();
            if (await commentService.SameUserAsync(Id, userId) == false)
            {
                return RedirectToAction(nameof(All));
            };

            var eventModel = await commentService.CommentByIdAsync(Id);

            var model = new CommentToCreateViewModel()
            {
                Text = eventModel.Text,
                Id = eventModel.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommentToCreateViewModel model, int Id)
        {
            if (Id != model.Id)
            {
                return RedirectToAction(nameof(All));
            }

            if (await commentService.ExistsAsync(model.Id) == false)
            {
                ModelState.AddModelError("", "Comment does not exist");
                return View(model);
            }

            if (await commentService.SameUserAsync(model.Id, User.Id()) == false)
            {
                return RedirectToAction(nameof(All));
            };

            var result = await commentService.EditAsync(Id, model);

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            return RedirectToAction(nameof(All), new { Id = result });
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
