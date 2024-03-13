using SoftUniFinalProject.Core.Models.Team;

namespace SoftUniFinalProject.Core.Contracts.Team
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamsAllViewModel>> AllTeams();
    }
}
