using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Infrastructure.Constants;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.Models;

namespace SoftUniFinalProject.Core.Services.TeamService
{
    public class SponsorService : ISponsorService
    {
        private readonly IRepository repository;

        public SponsorService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<SponsorServiceViewModel>> SponsorsAll()
        {
            return await repository.AllReadOnly<Sponsor>()
                .Select(s => new SponsorServiceViewModel()
                {
                    Name = s.Name,
                    ImageUrl = s.ImageUrl,
                    NetWorthInBillion = s.NetWorthInBillion,
                    StartOn = s.StartOn.ToString(DataConstants.DateTimeFormat),
                }).ToListAsync();
        }
    }
}
