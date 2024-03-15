using Microsoft.EntityFrameworkCore;
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

        public TeamService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<TeamsAllViewModel>> AllTeams()
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

        public async Task<TeamsAllViewModel> GetTeamDetails(int teamId)
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
