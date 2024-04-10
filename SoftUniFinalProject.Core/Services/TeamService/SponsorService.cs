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

        public async Task<IEnumerable<SponsorServiceViewModel>> AllSponsorsAsync()
        {
            return await repository.AllReadOnly<Sponsor>()
                .Select(x => new SponsorServiceViewModel() 
                { 
                    ImageUrl = x.ImageUrl,
                    Name = x.Name,
                    NetWorthInBillion = x.NetWorthInBillion,
                    YearCreated = x.YearCreation,
                    Id = x.Id,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AddSponsorToTeamViewModel>> AllSponsorsToAddAsync()
        {
            return await repository.AllReadOnly<Sponsor>()
                .Select(x => new AddSponsorToTeamViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync();
        }

        public async Task<bool> SponsorExistAsync(int sponsorId)
        {
            return await repository.AllReadOnly<Sponsor>()
                .AnyAsync(s => s.Id == sponsorId);
        }

        public async Task<IEnumerable<SponsorServiceViewModel>> SponsorsByTeamAsync(int teamId)
        {
            return await repository.AllReadOnly<Sponsor>()
                .Where(s => s.TeamsSponsors.Any(ts => ts.TeamId == teamId))
                .Select(s => new SponsorServiceViewModel()
                {
                    Name = s.Name,
                    ImageUrl = s.ImageUrl,
                    NetWorthInBillion = s.NetWorthInBillion,
                    YearCreated = s.YearCreation
                }).ToListAsync();
        }
    }
}
