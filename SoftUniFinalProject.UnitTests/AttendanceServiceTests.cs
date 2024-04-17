using Microsoft.EntityFrameworkCore;
using Moq;
using SoftUniFinalProject.Core.Services.AttendanceService;
using SoftUniFinalProject.Infrastructure.Data;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System.Linq.Expressions;

namespace SoftUniFinalProject.UnitTests
{
    [TestFixture]
    public class AttendanceServiceTests
    {
        private IRepository repository;
        private AttendanceService attendanceService;
        private FootballEventDbContext context;
        private ApplicationUser userAdmin;
        private Event eventForTest;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FootballEventDbContext>()
                .UseInMemoryDatabase("FootballEventsTestDB")
                .Options;

            context = new FootballEventDbContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            userAdmin = new ApplicationUser()
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

            eventForTest = new Event
            {
                Id = 100,
                Name = "Test",
                Description = "Test",
                FootballGameId = 1,
                Location = "TestLocation",
                OrganiserId = userAdmin.Id,
                Organiser = userAdmin,
                StartOn = DateTime.Now
            };
            context.Events.Add(eventForTest);

            context.EventsParticipants.Add(new EventParticipant
            {
                UserId = userAdmin.Id,
                Event = eventForTest
            });


            context.SaveChanges();
            repository = new Repository(context);
            attendanceService = new AttendanceService(repository);
        }

        [Test]
        public async Task GetMyEventsAsync_ReturnsEventsForUser()
        {
            //Arrange && Act
            var result = await attendanceService.GetMyEventsAsync(userAdmin.Id);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task JoinEventAsync_ParticipantNotAlreadyJoined_AddsParticipantAndSavesChanges()
        {
            //Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AlreadyExistAsync<EventParticipant>(It.IsAny<Expression<Func<EventParticipant, bool>>>()))
                          .ReturnsAsync(false);
            mockRepository.Setup(r => r.GetByIdAsync<Event>(eventForTest.Id))
                          .ReturnsAsync(new Event { Id = eventForTest.Id, EventParticipants = new List<EventParticipant>() });

            var service = new AttendanceService(mockRepository.Object);

            // Act
            var result = await service.JoinEventAsync(eventForTest.Id, userAdmin.Id);

            // Assert
            Assert.True(result);
            mockRepository.Verify(r => r.AddAsync(It.IsAny<EventParticipant>()), Times.Once);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task LeaveEventAsync_ParticipantExists_RemovesParticipantAndSavesChanges()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.FirstOrDefaultAsync<EventParticipant>(It.IsAny<Expression<Func<EventParticipant, bool>>>()))
                          .ReturnsAsync(new EventParticipant { EventId = eventForTest.Id, UserId = userAdmin.Id });

            var service = new AttendanceService(mockRepository.Object);

            // Act
            var result = await service.LeaveEventAsync(eventForTest.Id, userAdmin.Id);

            // Assert
            Assert.True(result); // Verify that the method returns true
            mockRepository.Verify(r => r.Delete(It.IsAny<EventParticipant>()), Times.Once);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once); 
        }

        [Test]
        public async Task LeaveEventAsync_ParticipantDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.FirstOrDefaultAsync<EventParticipant>(It.IsAny<Expression<Func<EventParticipant, bool>>>()))
                          .ReturnsAsync((EventParticipant)null);

            var service = new AttendanceService(mockRepository.Object);

            // Act
            var result = await service.LeaveEventAsync(eventForTest.Id, userAdmin.Id);

            // Assert
            Assert.False(result); // Verify that the method returns false
            mockRepository.Verify(r => r.Delete(It.IsAny<EventParticipant>()), Times.Never); 
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Never);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
