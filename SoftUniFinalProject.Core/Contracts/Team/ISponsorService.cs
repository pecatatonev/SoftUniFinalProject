using SoftUniFinalProject.Core.Models.Team;

namespace SoftUniFinalProject.Core.Contracts.Team
{
    public interface ISponsorService
    {
        Task<IEnumerable<SponsorServiceViewModel>> SponsorsAll();
    }
}
