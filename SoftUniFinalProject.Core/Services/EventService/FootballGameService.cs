using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Infrastructure.Constants;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Services.EventService
{
    public class FootballGameService : IFootballGameService
    {
        private readonly IRepository repository;
        private readonly ILogger<EventService> logger;
        public FootballGameService(IRepository _repository, ILogger<EventService> _logger)
        {
            repository = _repository;
            logger = _logger;
        }

        public async Task<int> CreateAsync(AddFootballGameViewModel model)
        {
            if (await repository.AlreadyExistAsync<FootballGame>(fb => fb.PlayingFor == model.PlayingFor && fb.RefereeName == model.RefereeName))
            {
                throw new ApplicationException("Football game already exists");
            }

            DateTime start = DateTime.Now;

            if (!DateTime.TryParseExact(model.StartGame,
            DataConstants.DateTimeFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out start))
            {
                return -1;
            }

            if (model.AwayTeamId == model.HomeTeamId)
            {
                return -2;
            }

            FootballGame footballGame = new FootballGame()
            {
                PlayingFor = model.PlayingFor,
                RefereeName = model.RefereeName,
                StartGame = start,
                AwayTeamId = model.AwayTeamId,
                HomeTeamId = model.HomeTeamId,
            };

            try
            {
                await repository.AddAsync(footballGame);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(CreateAsync), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }


            return footballGame.Id;
        }

        public async Task<int> DeleteFinishedGamesAsync()
        {
            var footballGames =await repository.All<FootballGame>().ToListAsync();
            var dateNow = DateTime.Now;
            int countDeleted = 0;
            if (footballGames == null)
            {
                return 0;
            }
            foreach (var fb in footballGames)
            {
                if (fb.StartGame < dateNow)
                {
                    repository.Delete(fb);
                    countDeleted++;
                }
            }

            await repository.SaveChangesAsync();

            return countDeleted;
        }

        public async Task<bool> FootballGameExistAsync(int footballGameId)
        {
            return await repository.AllReadOnly<FootballGame>()
                .AnyAsync(fb => fb.Id == footballGameId);
        }

        public async Task<IEnumerable<FootballGameToAddViewModel>> GetAllFootballGamesAsync()
        {
            return await repository.AllReadOnly<FootballGame>()
                .Select(x => new FootballGameToAddViewModel()
                {
                    Id = x.Id,
                    AwayTeamName = x.AwayTeam.Name,
                    HomeTeamName = x.HomeTeam.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<FootballGameAllViewModel>> GetAllFootballGamesInAdminAsync()
        {
            return await repository.AllReadOnly<FootballGame>()
                .Select(x => new FootballGameAllViewModel()
                {
                    Id = x.Id,
                    RefereeName = x.RefereeName,
                    PlayingFor = x.PlayingFor,
                    StartGame = x.StartGame.ToString(DataConstants.DateTimeFormat),
                    AwayTeamName = x.AwayTeam.Name,
                    HomeTeamName= x.HomeTeam.Name,
                }).ToListAsync();
        }

        public async Task<FootballGameViewModel> GetFootballDetailsAsync(int Id)
        {
            return await repository.AllReadOnly<FootballGame>()
               .Where(fb => fb.Id == Id)
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

        public async Task<FootballGame> GetFootballGameById(int Id)
        {
            return await repository.GetByIdAsync<FootballGame>(Id);
        }
    }
}
