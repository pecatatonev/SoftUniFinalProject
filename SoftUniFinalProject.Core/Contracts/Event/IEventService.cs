using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Models.Team;

namespace SoftUniFinalProject.Core.Contracts.Event
{
    public interface IEventService
    {
        Task<IEnumerable<EventAllViewModel>> AllEventsAsync();

        Task<int> CreateAsync(AddEventViewModel model, string userId);

        Task<Infrastructure.Data.Models.Event> EventByIdAsync(int id);

        Task<bool> ExistsAsync(int id);
        Task<bool> SameOrganiserAsync(int eventId, string currentUserId);

        Task<int> Edit(int eventId, AddEventViewModel model);
    }
}
