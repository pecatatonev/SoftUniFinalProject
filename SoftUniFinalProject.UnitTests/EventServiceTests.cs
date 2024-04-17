using Microsoft.EntityFrameworkCore;
using Moq;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Services.EventService;
using SoftUniFinalProject.Infrastructure.Data;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using SoftUniFinalProject.Infrastructure.Data.Models;
using SoftUniFinalProject.Infrastructure.Enumerations;
using System.Linq.Expressions;

namespace SoftUniFinalProject.UnitTests
{
    [TestFixture]
    public class EventServiceTests
    {
        private IRepository repository;
        private IEventService eventService;
        private FootballEventDbContext context;
        private ApplicationUser userAdmin;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FootballEventDbContext>()
                .UseInMemoryDatabase("FootballEventsTestDB")
                .Options;

            context = new FootballEventDbContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            userAdmin = new Infrastructure.Data.IdentityModels.ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395022",
                UserName = "host3663",
                NormalizedUserName = "HOST3663",
                Email = "host@football.com",
                NormalizedEmail = "host@football.com",
                FirstName = "Host",
                LastName = "User"
            };
            context.Users.Add(userAdmin);
            context.Events.AddRange(new List<Event>
            {
                new Event { Id = 100,
                Name = "Test",
                Description = "Test",
                FootballGameId = 1,
                Location = "TestLocation",
                OrganiserId = userAdmin.Id,
                Organiser = userAdmin,
                StartOn = DateTime.Now},
                new Event { Id = 101,
                Name = "Test2",
                Description = "Test2",
                FootballGameId = 2,
                Location = "TestLocation2",
                OrganiserId = userAdmin.Id,
                Organiser = userAdmin,
                StartOn = DateTime.Now.AddDays(2)
                }  
            });



            context.SaveChanges();
            repository = new Repository(context);
            eventService = new EventService(repository);
        }

        [Test]
        public async Task CreateAsync_SuccessfullyCreatesEvent()
        {
            //Arrange
            var result = await eventService.CreateAsync(new AddEventViewModel()
            {
                Name = "Test3",
                Description= "Test3",
                Location = "TestLocation3",
                StartOn = "01/01/2025 15:00"
            }, userAdmin.Id);

            var dbEvent = await repository.GetByIdAsync<Event>(103);
            // Act & Assert
            Assert.That(result, Is.EqualTo(103));
            Assert.That(dbEvent.Location, Is.EqualTo("TestLocation3"));
            Assert.That(dbEvent.Name, Is.EqualTo("Test3"));
        }

        [Test]
        public async Task CreateAsync_ThrowsExceptionWhenEventIsAlreadyCreated()
        {   // Act & Assert
            Assert.ThrowsAsync<ApplicationException>(() => eventService.CreateAsync(new AddEventViewModel()
            {
                Name = "Test",
                Description = "Test",
                Location = "TestLocation",
                StartOn = "01/01/2025 15:00"
            }, userAdmin.Id));
        }

        [Test]
        public async Task CreateAsync_InvalidDateFormat_ReturnsMinusOne()
        {   //Arrange
            var result = await eventService.CreateAsync(new AddEventViewModel()
            {
                Name = "Test3",
                Description = "Test3",
                Location = "TestLocation3",
                StartOn = "01.01.2025 15:00"
            }, userAdmin.Id);
            // Act & Assert
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void CreateAsync_DatabaseException_ThrowsApplicationException()
        {
            // Arrange
            var model = new AddEventViewModel
            {

                Name = "Test",
                Description = "Test",
                Location = "TestLocation",
                StartOn = "01/01/2025 15:00"
            };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AlreadyExistAsync(It.IsAny<Expression<Func<Event, bool>>>()))
              .ReturnsAsync(false);
            mockRepository.Setup(r => r.AddAsync(It.IsAny<EventParticipant>())).ThrowsAsync(new Exception());
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Event>())).ThrowsAsync(new Exception());

            var service = new EventService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<ApplicationException>(() => service.CreateAsync(model, userAdmin.Id));
        }

        [Test]
        public async Task DeleteAsync_DeletesEventAndAssociatedEntities()
        {
            // Arrange
            int eventId = 1;

            var mockRepository = new Mock<IRepository>();
            var service = new EventService(mockRepository.Object);

            var eventToDelete = new Event { Id = eventId };
            mockRepository.Setup(r => r.GetByIdAsync<Event>(eventId)).ReturnsAsync(eventToDelete);

            var joinedUsers = new[] { new EventParticipant(), new EventParticipant() };
            mockRepository.Setup(r => r.All<EventParticipant>(ep => ep.EventId == eventId)).Returns(joinedUsers.AsQueryable());

            var comments = new[] { new Comment(), new Comment() };
            mockRepository.Setup(r => r.All<Comment>(c => c.EventId == eventId)).Returns(comments.AsQueryable());

            // Act
            await service.DeleteAsync(eventId);

            // Assert
            mockRepository.Verify(r => r.DeleteRange(joinedUsers), Times.Once);
            mockRepository.Verify(r => r.DeleteRange(comments), Times.Once);
            mockRepository.Verify(r => r.Delete(eventToDelete), Times.Once);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void DeleteAsync_EventNotFound_ThrowsException()
        {
            // Arrange
            int eventId = 1;

            var mockRepository = new Mock<IRepository>();
            var service = new EventService(mockRepository.Object);

            mockRepository.Setup(r => r.GetByIdAsync<Event>(eventId)).ReturnsAsync((Event)null);

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(() => service.DeleteAsync(eventId));
        }

        [Test]
        public async Task DeleteAsync_DatabaseException_ThrowsApplicationException()
        {
            // Arrange
            int eventId = 1;

            var mockRepository = new Mock<IRepository>();
            var service = new EventService(mockRepository.Object);

            var eventToDelete = new Event { Id = eventId };
            mockRepository.Setup(r => r.GetByIdAsync<Event>(eventId)).ReturnsAsync(eventToDelete);

            var joinedUsers = new[] { new EventParticipant(), new EventParticipant() };
            mockRepository.Setup(r => r.All<EventParticipant>(ep => ep.EventId == eventId)).Returns(joinedUsers.AsQueryable());

            var comments = new[] { new Comment(), new Comment() };
            mockRepository.Setup(r => r.All<Comment>(c => c.EventId == eventId)).Returns(comments.AsQueryable());

            mockRepository.Setup(r => r.SaveChangesAsync()).ThrowsAsync(new Exception("Database failed to save info"));

            // Act & Assert
            var ex = Assert.ThrowsAsync<ApplicationException>(() => service.DeleteAsync(eventId));
            Assert.That(ex.Message, Is.EqualTo("Database failed to save info"));
            Assert.IsInstanceOf<Exception>(ex.InnerException);
        }

        [Test]
        public async Task EditAsync_EditsEventSuccessfully()
        {
            // Arrange
            int eventId = 103;
            var model = new AddEventViewModel
            {
                Id = eventId,
                Name = "Test3",
                Description = "Test3",
                Location = "TestLocation3",
                StartOn = "01/01/2025 15:00",
                FootballGameId = 1
            };

            var mockRepository = new Mock<IRepository>();
            var service = new EventService(mockRepository.Object);

            var eventToEdit = new Event { Id = eventId };
            mockRepository.Setup(r => r.GetByIdAsync<Event>(eventId)).ReturnsAsync(eventToEdit);

            // Act
            var result = await service.EditAsync(eventId, model);

            // Assert
            Assert.That(result, Is.EqualTo(eventId));
            Assert.That(eventToEdit.Name, Is.EqualTo(model.Name));
            Assert.That(eventToEdit.Location, Is.EqualTo(model.Location));
            Assert.That(eventToEdit.StartOn, Is.EqualTo(DateTime.Parse(model.StartOn)));
            Assert.That(eventToEdit.Description, Is.EqualTo(model.Description));
            Assert.That(eventToEdit.FootballGameId, Is.EqualTo(model.FootballGameId));
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task EditAsync_EventIdNotFound_ReturnsMinusOne()
        {
            // Arrange
            int eventId = 1;
            var model = new AddEventViewModel();

            var mockRepository = new Mock<IRepository>();
            var service = new EventService(mockRepository.Object);

            mockRepository.Setup(r => r.GetByIdAsync<Event>(eventId)).ReturnsAsync((Event)null);

            // Act
            var result = await service.EditAsync(eventId, model);

            // Assert
            Assert.That(result, Is.EqualTo(-1));
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Never);
        }

        [Test]
        public async Task EditAsync_InvalidDateFormat_ReturnsMinusOne()
        {
            // Arrange
            int eventId = 1;
            var model = new AddEventViewModel
            {
                StartOn = "01.01.2025 15:00",
            };

            var mockRepository = new Mock<IRepository>();
            var service = new EventService(mockRepository.Object);

            var eventToEdit = new Event { Id = eventId };
            mockRepository.Setup(r => r.GetByIdAsync<Event>(eventId)).ReturnsAsync(eventToEdit);

            // Act
            var result = await service.EditAsync(eventId, model);

            // Assert
            Assert.That(result, Is.EqualTo(-1));
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Never);
        }

        [Test]
        public async Task EventByIdAsync_RetrievesEventSuccessfully()
        {
            // Arrange
            var eventId = 100;

            // Act
            var result = await eventService.EventByIdAsync(eventId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(eventId));
            Assert.That(result.Location, Is.EqualTo("TestLocation"));
        }

        [Test]
        public async Task ExistsAsync_EventExists_ReturnsTrue()
        {
            // Arrange
            int eventId = 101;

            // Act
            var result = await eventService.ExistsAsync(eventId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsAsync_EventDoesNotExist_ReturnsFalse()
        {
            // Arrange
            int eventId = 104;

            // Act
            var result = await eventService.ExistsAsync(eventId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AllSortingAsync_ReturnsExpectedResult()
        {
                // Act
                var result = await eventService.AllSortingAsync(searchTerm:"Test", sorting:EventSorting.Soonest, currentPage: 1, eventPerPage: 2);

                // Assert
                Assert.IsNotNull(result);
                Assert.That(result.Events.Count(), Is.EqualTo(2));
                Assert.That(result.TotalEventCount, Is.EqualTo(2));
            }

            [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
