using SoftUniFinalProject.Core.Models.Event;

namespace SoftUniFinalProject.Core.Contracts.Event
{
    public interface IEventService
    {
        Task<IEnumerable<EventAllViewModel>> AllEventsAsync();
    }
}
