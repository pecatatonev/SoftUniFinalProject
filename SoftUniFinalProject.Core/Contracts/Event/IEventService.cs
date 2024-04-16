using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Infrastructure.Enumerations;

namespace SoftUniFinalProject.Core.Contracts.Event
{
    public interface IEventService
    {
        Task<EventQueryServiceModel> AllSortingAsync(string? searchTerm = null,
            EventSorting sorting = EventSorting.Soonest,
            int currentPage = 1,
            int eventPerPage = 1);

        Task<int> CreateAsync(AddEventViewModel model, string userId);

        Task<Infrastructure.Data.Models.Event> EventByIdAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<int> EditAsync(int eventId, AddEventViewModel model);

        Task DeleteAsync(int eventId);

        Task<IEnumerable<EventIndexViewModel>> LastThreeEvents();
    }
}
