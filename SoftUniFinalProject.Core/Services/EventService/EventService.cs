using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
            if (await repository.AlreadyExistAsync<Event>(e => e.Name == model.Name))
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

            EventParticipant participant = new EventParticipant()
            {
                EventId = footballEvent.Id,
                UserId = userId,
            };

            footballEvent.EventParticipants.Add(participant);
            try
            {
                await repository.AddAsync(participant);
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

        public async Task DeleteAsync(int eventId)
        {
            var eventToDelete = await repository.GetByIdAsync<Event>(eventId);
            var joinedUsers = repository.All<EventParticipant>(ep => ep.EventId == eventId);
            var comments = repository.All<Comment>(c => c.EventId == eventId);
            repository.DeleteRange(joinedUsers);
            repository.DeleteRange(comments);
            repository.Delete(eventToDelete);


            await repository.SaveChangesAsync();
        }

        public async Task<int> Edit(int eventId, AddEventViewModel model)
        {
            var eventToEdit = await repository.GetByIdAsync<Event>(eventId);

            DateTime start = DateTime.Now;

            if (!DateTime.TryParseExact(model.StartOn,
            DataConstants.DateTimeFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out start))
            {
                return -1;
            }

            eventToEdit.Name = model.Name;
            eventToEdit.Location = model.Location;
            eventToEdit.StartOn = start;
            eventToEdit.Description = model.Description;
            eventToEdit.FootballGameId = model.FootballGameId;
            eventToEdit.Id = model.Id;

            await repository.SaveChangesAsync();
            return eventToEdit.Id;
        }

        public async Task<Event> EventByIdAsync(int id)
        {
            return await repository.AllReadOnly<Event>()
                .Where(e => e.Id == id).FirstAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Event>().AnyAsync(e => e.Id == id);
        }

        public async Task<bool> SameOrganiserAsync(int eventId, string currentUserId)
        {
            bool result = false;
            var Event = await repository.AllReadOnly<Event>()
                .Where(e => e.Id == eventId)
                .FirstOrDefaultAsync();

            if (Event.OrganiserId == currentUserId)
            {
                result = true;
            }

            return result;
        }
    }
}
