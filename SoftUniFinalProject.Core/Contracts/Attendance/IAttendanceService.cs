using SoftUniFinalProject.Core.Models.Attendance;

namespace SoftUniFinalProject.Core.Contracts.Attendance
{
    public interface IAttendanceService
    {
        Task<bool> JoinEventAsync(int eventId, string userId);
        Task<bool> LeaveEventAsync(int eventId, string userId);
        Task<List<UserEventsViewModel>> GetMyEventsAsync(string userId);
    }
}
