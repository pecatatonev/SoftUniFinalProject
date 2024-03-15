using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Infrastructure.Constants;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.Models;

namespace SoftUniFinalProject.Core.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly IRepository repository;

        private readonly ILogger logger;
        public TeamService(IRepository _repository, ILogger<TeamService> _logger)
        {
            repository = _repository;
            logger = _logger;
        }
        public async Task<IEnumerable<TeamsAllViewModel>> AllTeamsAsync()
        {
            //Nickname null option check later
           return await repository.AllReadOnly<Team>()
                .Select(t => new TeamsAllViewModel 
                {
                    Id = t.Id,
                    Name = t.Name,
                    StadiumCapacity = t.StadiumCapacity,
                    YearCreated = t.YearOfCreation,
                    ImageUrl = t.ImageUrl,
                    StadiumName = t.Name,
                    Nickname = t.Nickname,
                    ManagerName = t.ManagerName,
                })
                .ToListAsync();
        }

        public async Task<int> CreateAsync(AddTeamViewModel model)
        {
            if (await repository.AlreadyExistAsync<Team>(t => t.Name == model.Name))
            {
                throw new ApplicationException("Team already exists");
            }

            Team team = new Team() 
            {
                Name = model.Name,
                ManagerName= model.ManagerName,
                Nickname= model.Nickname,
                StadiumCapacity= model.StadiumCapacity,
                YearOfCreation= model.YearOfCreation,
                ImageUrl= model.ImageUrl,
                StadiumName= model.Name,
            };

            TeamSponsor teamSponsor = new TeamSponsor() 
            {
                TeamId = team.Id,
                SponsorId = model.SponsorId
            };
            team.TeamsSponsors.Add(teamSponsor);

            try
            {
                await repository.AddAsync(team);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(CreateAsync), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
            
            
            return team.Id;
        }

        public async Task<TeamsAllViewModel> GetTeamDetailsAsync(int teamId)
        {
            return await repository.AllReadOnly<Team>()
                .Where(t => t.Id == teamId)
                .Select(t => new TeamsAllViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    StadiumCapacity = t.StadiumCapacity,
                    YearCreated = t.YearOfCreation,
                    ImageUrl = t.ImageUrl,
                    StadiumName = t.Name,
                    Nickname = t.Nickname,
                    ManagerName = t.ManagerName,
                })
                .FirstAsync();
        }
    }
}
