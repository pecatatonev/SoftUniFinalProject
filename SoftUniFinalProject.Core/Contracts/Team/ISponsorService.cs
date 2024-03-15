using SoftUniFinalProject.Core.Models.Team;

namespace SoftUniFinalProject.Core.Contracts.Team
{
    public interface ISponsorService
    {
        Task<IEnumerable<SponsorServiceViewModel>> SponsorsByTeamAsync(int teamId);

        Task<IEnumerable<SponsorServiceViewModel>> AllSponsorsAsync();

        Task<bool> SponsorExistAsync(int sponsorId);
    }
}
