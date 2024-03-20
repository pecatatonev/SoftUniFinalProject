using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Attendance;
using SoftUniFinalProject.Core.Models.Attendance;
using SoftUniFinalProject.Infrastructure.Constants;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.Models;

namespace SoftUniFinalProject.Core.Services.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IRepository _repository;

        public AttendanceService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> JoinEventAsync(int eventId, string userId)
        {
            
            if (await _repository.AlreadyExistAsync<EventParticipant>(e => e.EventId == eventId && e.UserId == userId))
            {
                
                return false;
            }

            
            await _repository.AddAsync(new EventParticipant { EventId = eventId, UserId = userId });
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LeaveEventAsync(int eventId, string userId)
        {
            var attendance = await _repository.FirstOrDefaultAsync<EventParticipant>(e => e.EventId == eventId && e.UserId == userId);
            if (attendance == null)
            {
                return false;
            }

            
            _repository.Delete(attendance);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserEventsViewModel>> GetMyEventsAsync(string userId)
        {
            return await _repository.AllReadOnly<EventParticipant>()
                .Where(a => a.UserId == userId)
                .Include(a => a.Event)
                .Select(ep => new UserEventsViewModel
                {
                    Description = ep.Event.Description,
                    FootballGameId = ep.Event.FootballGameId,
                    Id = ep.Event.Id,
                    Location = ep.Event.Location,
                    Name = ep.Event.Name,
                    Organiser = ep.Event.Organiser.UserName,
                    StartOn = ep.Event.StartOn.ToString(DataConstants.DateTimeFormat),
                })
                .ToListAsync();
        }
    }
}

