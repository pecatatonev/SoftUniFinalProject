using Microsoft.AspNetCore.Identity;
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
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Services.EventService
{
    public class EventService : IEventService
    {
        private readonly IRepository repository;

        private readonly ILogger<EventService> logger;
        public EventService(IRepository _repository, ILogger<EventService> _logger)
        {
            repository = _repository;
            logger = _logger;
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

        public async Task<int> CreateAsync(AddEventViewModel model, string userId)
        {
            if (await repository.AlreadyExistAsync<Event>(e => e.Id == model.Id))
            {
                throw new ApplicationException("Event already exists");
            }

            DateTime start = DateTime.Now;
 
            if (!DateTime.TryParseExact(model.StartOn,
            DataConstants.DateTimeFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out start))
            {
                return -1;
            }

            Event footballEvent = new Event()
            {
                Description = model.Description,
                StartOn = start,
                Location = model.Location,
                Name = model.Name,
                OrganiserId = userId,
                FootballGameId = model.FootballGameId,
            };

            try
            {
                await repository.AddAsync(footballEvent);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(CreateAsync), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }


            return footballEvent.Id;
        }
    }
}
