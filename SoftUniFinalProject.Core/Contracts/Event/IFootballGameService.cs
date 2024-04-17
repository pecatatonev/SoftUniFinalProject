using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Infrastructure.Data.Models;

namespace SoftUniFinalProject.Core.Contracts.Event
{
    public interface IFootballGameService
    {
        Task<FootballGameViewModel> GetFootballDetailsAsync(int footballGameId);

        Task<IEnumerable<FootballGameToAddViewModel>> GetAllFootballGamesAsync();
        Task<IEnumerable<FootballGameAllViewModel>> GetAllFootballGamesInAdminAsync();

        Task<bool> FootballGameExistAsync(int sponsorId);

        Task<int> CreateAsync(AddFootballGameViewModel model);

        Task<int> DeleteFinishedGamesAsync();

        Task<FootballGame> GetFootballGameById(int Id);
    }
}
