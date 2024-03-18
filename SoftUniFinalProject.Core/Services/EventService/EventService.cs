using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Models.Event;
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
    public class EventService : IEventService
    {
        private readonly IRepository repository;

        public EventService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<EventAllViewModel>> AllEventsAsync()
        {
            return await repository.AllReadOnly<Event>()
                .Select(e => new EventAllViewModel() 
                {
                    Id = e.Id,
                    Description = e.Description,
                    Location = e.Location,
                    Name = e.Name,
                    StartOn = e.StartOn.ToString(DataConstants.DateTimeFormat),
                    FootballGameId = e.FootballGameId,
                    Organiser = e.Organiser.UserName,
                })
                .ToListAsync();
        }
    }
}
