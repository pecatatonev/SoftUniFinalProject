using SoftUniFinalProject.Core.Models.Team;

namespace SoftUniFinalProject.Core.Contracts.Team
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamsAllViewModel>> AllTeamsAsync();

        Task<TeamsAllViewModel> GetTeamDetailsAsync(int teamId);

        Task<int> CreateAsync(AddTeamViewModel model);
    }
}
