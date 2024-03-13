﻿using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Infrastructure.Constants;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           return await repository.AllReadOnly<Team>()
                .Select(t => new TeamsAllViewModel 
                {
                    Id = t.Id,
                    Name = t.Name,
                    StadiumCapacity = t.StadiumCapacity,
                    YearCreated = t.YearCreated.ToString(DataConstants.DateTimeFormat),
                    ImageUrl = t.ImageUrl,
                    StadiumName = t.Name,
                    Nickname = t.Nickname,
                    ManagerName = t.ManagerName,
                })
                .ToListAsync();
        }
    }
}
