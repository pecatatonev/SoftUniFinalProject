﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniFinalProject.Core.Contracts.Attendance;
using SoftUniFinalProject.Extensions;

namespace SoftUniFinalProject.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService attendanceService;

        public AttendanceController(IAttendanceService _attendanceService)
        {
            attendanceService = _attendanceService;
        }

        [HttpPost]
        public async Task<IActionResult> Join(int Id)
        {
            var userId = User.Id();
            var success = await attendanceService.JoinEventAsync(Id, userId);
            if (success)
            {
                return RedirectToAction(nameof(MyEvents));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int Id)
        {
            var userId = User.Id();
            var success = await attendanceService.LeaveEventAsync(Id, userId);
            if (success)
            {
                return RedirectToAction(nameof(MyEvents));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyEvents()
        {
            var userId = User.Id();
            var events = await attendanceService.GetMyEventsAsync(userId);
            return View(events);
        }
    }
}
