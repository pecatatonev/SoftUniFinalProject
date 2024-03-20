using SoftUniFinalProject.Core.Models.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Contracts.Attendance
{
    public interface IAttendanceService
    {
        Task<bool> JoinEventAsync(int eventId, string userId);
        Task<bool> LeaveEventAsync(int eventId, string userId);
        Task<List<UserEventsViewModel>> GetMyEventsAsync(string userId);
    }
}
