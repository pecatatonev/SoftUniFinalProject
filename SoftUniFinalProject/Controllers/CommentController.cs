﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Comment;
using SoftUniFinalProject.Core.Models.Comment;
using SoftUniFinalProject.Extensions;
using SoftUniFinalProject.Infrastructure.Constants;
using System.Globalization;
using static SoftUniFinalProject.Core.Constants.RoleConstants;

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
            ViewBag.Id = Id;
            var model = await commentService.GetAllCommentsForEventAsync(Id);
            if (model == null)
            {
                return NotFound();
            }
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
        public async Task<IActionResult> Edit(int Id, int eventId)
        {
            if ((await commentService.ExistsAsync(Id)) == false)
            {
                return RedirectToAction(nameof(All), new { Id = eventId });
            }

            var userId = User.Id();
            if (await commentService.SameUserAsync(Id, userId) == false)
            {
                return RedirectToAction(nameof(All), new { Id = eventId });
            };

            var eventModel = await commentService.CommentByIdAsync(Id);

            var model = new CommentToCreateViewModel()
            {
                Text = eventModel.Text,
                Id = eventModel.Id,
                EventId = eventId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommentToCreateViewModel model, int Id)
        {
            if (Id != model.Id)
            {
                return RedirectToAction(nameof(All), new { Id = model.EventId });
            }

            if (await commentService.ExistsAsync(model.Id) == false)
            {
                ModelState.AddModelError("", "Comment does not exist");
            }

            if (await commentService.SameUserAsync(model.Id, User.Id()) == false)
            {
                return RedirectToAction(nameof(All), new { Id = model.EventId });
            };

            var result = await commentService.EditAsync(Id, model);

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            return RedirectToAction(nameof(All), new { Id = result });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id, int eventId)
        {
            if ((await commentService.ExistsAsync(Id) == false))
            {
                return RedirectToAction(nameof(All), new { Id = eventId });
            }

            if (await commentService.SameUserAsync(Id, User.Id()) == false && !User.IsInRole(AdministratorRole))
            {
                return RedirectToAction(nameof(All), new { Id = eventId });
            };

            var commentToDelete = await commentService.CommentByIdWithUserAsync(Id);
            var model = new CommentDeleteViewModel()
            {
                Text = commentToDelete.Text,
                PublicationTime = commentToDelete.PublicationTime.ToString(DataConstants.DateTimeFormat, CultureInfo.InvariantCulture),
                UserName = commentToDelete.User.UserName,
                EventId = eventId,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CommentDeleteViewModel model, int Id)
        {
            if ((await commentService.ExistsAsync(Id) == false))
            {
                return RedirectToAction(nameof(All), new { Id = model.EventId });
            }

            if (await commentService.SameUserAsync(Id, User.Id()) == false && !User.IsInRole(AdministratorRole))
            {
                return RedirectToAction(nameof(All), new { Id = model.EventId });
            };

            await commentService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All), new { Id = model.EventId });
        }
    }
}
