using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Infrastructure.Enumerations;

namespace SoftUniFinalProject.Core.Contracts.Team
{
    public interface ITeamService
    {
        Task<TeamQueryServiceModel> AllSortingAsync(string? searchTerm = null,
            TeamSorting sorting = TeamSorting.NewestAdded,
            int currentPage = 1,
            int eventPerPage = 1);

        Task<TeamsAllViewModel> GetTeamDetailsAsync(int teamId);

        Task<int> CreateAsync(AddTeamViewModel model);

        Task<IEnumerable<AddTeamToFootballGameViewModel>> GetAllTeamsAsync();

        Task<IEnumerable<AddTeamToSponsorViewModel>> GetAllTeamsForSponsorAsync();

        Task<bool> TeamExistAsync(int teamId);
    }
}
