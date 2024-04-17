using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Infrastructure.Data.Models;

namespace SoftUniFinalProject.Core.Contracts.Team
{
    public interface ISponsorService
    {
        Task<IEnumerable<SponsorServiceViewModel>> SponsorsByTeamAsync(int teamId);

        Task<IEnumerable<SponsorServiceViewModel>> AllSponsorsAsync();

        Task<IEnumerable<AddSponsorToTeamViewModel>> AllSponsorsToAddAsync();
        Task<bool> SponsorExistAsync(int sponsorId);

        Task<int> CreateAsync(CreateSponsorViewModel model);

        Task<Sponsor> GetSponsorAsync(int sposnorId);

        Task DeleteAsync(int sponsorId);
    }
}
