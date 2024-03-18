using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Models.Team;

namespace SoftUniFinalProject.Core.Contracts.Event
{
    public interface IEventService
    {
        Task<IEnumerable<EventAllViewModel>> AllEventsAsync();

        Task<int> CreateAsync(AddEventViewModel model, string userId);
    }
}
