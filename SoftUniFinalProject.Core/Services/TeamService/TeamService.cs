﻿using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.Models;
using SoftUniFinalProject.Infrastructure.Enumerations;

namespace SoftUniFinalProject.Core.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly IRepository repository;
        public TeamService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<TeamQueryServiceModel> AllSortingAsync(string? searchTerm = null, TeamSorting sorting = TeamSorting.NewestAdded, int currentPage = 1, int teamPerPage = 1)
        {
            var teamsToShow = repository.AllReadOnly<Team>();

            if (searchTerm != null)
            {
                string normalizedSearch = searchTerm.ToLower();
                teamsToShow = teamsToShow
                    .Where(t => (t.Name.ToLower().Contains(normalizedSearch) ||
                    t.ManagerName.ToLower().Contains(normalizedSearch) ||
                    t.StadiumName.ToLower().Contains(normalizedSearch)));
            }

            teamsToShow = sorting switch
            {
                TeamSorting.CapacityStadium => teamsToShow.OrderBy(t => t.StadiumCapacity),
                TeamSorting.Oldest => teamsToShow.OrderBy(t => t.YearOfCreation),
                _ => teamsToShow.OrderByDescending(t => t.Id)
            };

            var teams = await teamsToShow
                .Skip((currentPage - 1) * teamPerPage)
                .Take(teamPerPage)
                .Select(e => new TeamsAllViewModel()
                {
                    Id = e.Id,
                    ImageUrl = e.ImageUrl,
                    ManagerName = e.ManagerName,
                    Name = e.Name,
                    Nickname = e.Nickname,
                    StadiumCapacity = e.StadiumCapacity,
                    StadiumName = e.StadiumName,
                    YearOfCreation = e.YearOfCreation,
                })
                .ToListAsync();

            int totalEvents = await teamsToShow.CountAsync();

            return new TeamQueryServiceModel()
            {
                Teams = teams,
                TotalTeamsCount = totalEvents
            };
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

            foreach (var sponsorId in model.SelectedSponsors)
            {
                TeamSponsor teamSponsor = new TeamSponsor()
                {
                    TeamId = team.Id,
                    SponsorId = sponsorId
                };
                team.TeamsSponsors.Add(teamSponsor);
            }

            try
            {
                await repository.AddAsync(team);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
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
                    YearOfCreation = t.YearOfCreation,
                    ImageUrl = t.ImageUrl,
                    StadiumName = t.StadiumName,
                    Nickname = t.Nickname,
                    ManagerName = t.ManagerName,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AddTeamToFootballGameViewModel>> GetAllTeamsAsync()
        {
            return await repository.AllReadOnly<Team>()
                .Select(t => new AddTeamToFootballGameViewModel()
                {
                    Id=t.Id,
                    Name=t.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AddTeamToSponsorViewModel>> GetAllTeamsForSponsorAsync()
        {
            return await repository.AllReadOnly<Team>()
                .Select(t => new AddTeamToSponsorViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }

        public async Task<bool> TeamExistAsync(int teamId)
        {
            if (await repository.FirstOrDefaultAsync<Team>(t => t.Id == teamId) == null)
            {
                return false;
            }

            return true;
        }
    }
}
