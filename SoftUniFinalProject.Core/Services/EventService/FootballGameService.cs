using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Infrastructure.Constants;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Services.EventService
{
    public class FootballGameService : IFootballGameService
    {
        private readonly IRepository repository;

        public FootballGameService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<FootballGameViewModel> GetFootballDetailsAsync(int footballGameId)
        {
            return await repository.AllReadOnly<FootballGame>()
               .Where(fb => fb.Id == footballGameId)
               .Select(fb => new FootballGameViewModel()
               {
                    Id = fb.Id,
                    PlayingFor = fb.PlayingFor,
                    StartGame = fb.StartGame.ToString(DataConstants.DateTimeFormat),
                    RefereeName = fb.RefereeName,
                    AwayTeamName = fb.AwayTeam.Name,
                    HomeTeamName = fb.HomeTeam.Name,
                    AwayTeamId = fb.AwayTeamId,
                    HomeTeamId = fb.HomeTeamId
               }).FirstOrDefaultAsync();


        }
    }
}
