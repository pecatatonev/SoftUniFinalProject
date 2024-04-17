using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Services.EventService;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using SoftUniFinalProject.Infrastructure.Data.Models;
using SoftUniFinalProject.Core.Models.Event;
using Moq;
using System.Linq.Expressions;
using SoftUniFinalProject.Infrastructure.Constants;
using System.Globalization;
using System.Collections;

namespace SoftUniFinalProject.UnitTests
{
    [TestFixture]
    public class FootballGameServiceTests
    {
        private IRepository repository;
        private IFootballGameService fbService;
        private FootballEventDbContext context;
        private ApplicationUser userAdmin;
        private Team teamHome;
        private Team teamAway;

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

            teamHome = new Team()
            {
                ImageUrl = "",
                ManagerName = "test",
                Name = "testHome",
                Nickname = "",
                StadiumCapacity = 10,
                StadiumName = "test",
                YearOfCreation = 1898,
                Id = 6
            };

            teamAway = new Team()
            {
                ImageUrl = "",
                ManagerName = "testA",
                Name = "testAway",
                Nickname = "",
                StadiumCapacity = 11,
                StadiumName = "testA",
                YearOfCreation = 1899,
                Id = 5,
            };
            DateTime start = DateTime.Now;

            DateTime.TryParseExact("01/01/2025 17:00",
            DataConstants.DateTimeFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out start);

                
                context.FootballGames.Add(new FootballGame()
            {
                PlayingFor = "Premier League Test",
                RefereeName = "Test Testing",
                StartGame = start,
                AwayTeamId = teamAway.Id,
                HomeTeamId = teamHome.Id,
                AwayTeam = teamAway,
                HomeTeam = teamHome,
                Id = 3
            });
            context.Users.Add(userAdmin);

            context.SaveChanges();
            repository = new Repository(context);
            fbService = new FootballGameService(repository);
        }

        [Test]
        public async Task CreateAsync_SuccessfullyCreatesFootballTeam()
        {
            //Arrange
            var result = await fbService.CreateAsync(new AddFootballGameViewModel()
            {
                PlayingFor = "Premier League Test 2",
                RefereeName = "Test Testing 2",
                StartGame ="01/01/2025 18:00",
                AwayTeamId = 24,
                HomeTeamId = 23,
                Id= 4
            });

            var dbEvent = await repository.GetByIdAsync<FootballGame>(4);
            // Act & Assert
            Assert.That(result, Is.EqualTo(4));
            Assert.That(dbEvent.RefereeName, Is.EqualTo("Test Testing 2"));
            Assert.That(dbEvent.PlayingFor, Is.EqualTo("Premier League Test 2"));
        }

        [Test]
        public async Task CreateAsync_ThrowsExceptionWhenFootballGameIsAlreadyCreated()
        {   // Act & Assert
            Assert.ThrowsAsync<ApplicationException>(() => fbService.CreateAsync(new AddFootballGameViewModel()
            {
                PlayingFor = "Premier League Test",
                RefereeName = "Test Testing",
                StartGame = "01/01/2025 18:00",
                AwayTeamId = teamAway.Id,
                HomeTeamId = teamHome.Id,
                Id = 3
            }));
        }

        [Test]
        public async Task CreateAsync_InvalidDateFormat_ReturnsMinusOne()
        {   //Arrange
            var result = await fbService.CreateAsync(new AddFootballGameViewModel()
            {
                PlayingFor = "Premier League Test2",
                RefereeName = "Test Testing2",
                StartGame = "01.01.2025 18:00",
                AwayTeamId = teamAway.Id,
                HomeTeamId = teamHome.Id,
                Id = 2
            });
            // Act & Assert
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void CreateAsync_DatabaseException_ThrowsApplicationException()
        {

            // Arrange
            var model = new AddFootballGameViewModel
            {

                PlayingFor = "Premier League Test2",
                RefereeName = "Test Testing2",
                StartGame = "01/01/2025 18:00",
                AwayTeamId = teamAway.Id,
                HomeTeamId = teamHome.Id,
                Id = 2
            };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AlreadyExistAsync(It.IsAny<Expression<Func<FootballGame, bool>>>())).ReturnsAsync(false);
            mockRepository.Setup(r => r.AddAsync(It.IsAny<FootballGame>())).ThrowsAsync(new ApplicationException());

            var service = new FootballGameService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<ApplicationException>(async () =>await service.CreateAsync(model));
        }

        [Test]
        public async Task DeleteFinishedGamesAsync_NoFootballGames_ReturnsZero()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.All<FootballGame>()).Returns(context.FootballGames.AsQueryable());

            var service = new FootballGameService(mockRepository.Object);

            // Act
            var result = await service.DeleteFinishedGamesAsync();

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task DeleteFinishedGamesAsync_SomeFinishedGames_DeletesAndReturnsCount()
        {
            // Arrange
            var dateNow = DateTime.Now;
            var footballGames = new List<FootballGame>
        {
            new FootballGame { StartGame = dateNow.AddHours(-1) },
            new FootballGame { StartGame = dateNow.AddHours(1) },
            new FootballGame { StartGame = dateNow.AddDays(-1) }
        };

            await context.AddRangeAsync(footballGames);
            await context.SaveChangesAsync();
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.All<FootballGame>()).Returns(context.FootballGames.AsQueryable());
            mockRepository.Setup(r => r.Delete(It.IsAny<FootballGame>())).Callback<FootballGame>(fb => footballGames.Remove(fb)).Verifiable();

            var service = new FootballGameService(mockRepository.Object);

            // Act
            var result = await service.DeleteFinishedGamesAsync();

            // Assert
            Assert.That(result, Is.EqualTo(2));
            mockRepository.Verify(r => r.Delete(It.IsAny<FootballGame>()), Times.Exactly(2));
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once); 
        }

        [Test]
        public async Task DeleteFinishedGamesAsync_NoFinishedGames_ReturnsZero()
        {
            // Arrange
            var dateNow = DateTime.Now;
            var footballGames = new List<FootballGame>
        {
            new FootballGame { StartGame = dateNow.AddHours(1) },
            new FootballGame { StartGame = dateNow.AddHours(2) }
        };

            await context.AddRangeAsync(footballGames);
            await context.SaveChangesAsync();
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.All<FootballGame>()).Returns(context.FootballGames.AsQueryable());

            var service = new FootballGameService(mockRepository.Object);

            // Act
            var result = await service.DeleteFinishedGamesAsync();

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task GetFootballGameById_WithValidId_ReturnsCorrectFootballGame()
        {
            // Arrange & Act
            repository = new Repository(context);
            fbService = new FootballGameService(repository);

            var result = await fbService.GetFootballGameById(3);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(3));
            Assert.That(result.PlayingFor, Is.EqualTo("Premier League Test"));
            Assert.That(result.StartGame, Is.EqualTo(DateTime.Parse("01.01.2025 17:00")));
            Assert.That(result.RefereeName, Is.EqualTo("Test Testing"));
            Assert.That(result.AwayTeamId, Is.EqualTo(5));
            Assert.That(result.HomeTeamId, Is.EqualTo(6));
        }

        [Test]
        public async Task ExistsAsync_FootballGameExists_ReturnsTrue()
        {
            // Arrange
            int eventId = 3;

            // Act
            var result = await fbService.FootballGameExistAsync(eventId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsAsync_FootballGameDoesNotExist_ReturnsFalse()
        {
            // Arrange
            int eventId = 104;

            // Act
            var result = await fbService.FootballGameExistAsync(eventId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetAllFootballGamesAsync_ReturnsMappedViewModels()
        {
            // Arrange
            var footballGames = new List<FootballGame>
        {
            new FootballGame { Id = 10, AwayTeam = new Team { Name = "Team A" }, HomeTeam = new Team { Name = "Team B" } },
            new FootballGame { Id = 11, AwayTeam = new Team { Name = "Team C" }, HomeTeam = new Team { Name = "Team D" } }
        };

            await context.AddRangeAsync(footballGames);
            await context.SaveChangesAsync();
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AllReadOnly<FootballGame>())
                          .Returns(context.FootballGames.AsQueryable());

            var service = new FootballGameService(mockRepository.Object);

            // Act
            var result = await service.GetAllFootballGamesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<FootballGameToAddViewModel>>(result);
            Assert.That(result.Count(), Is.EqualTo(4));

            // Verify that mappings are correct
            Assert.That(result.ElementAt(2).Id, Is.EqualTo(11));
            Assert.That(result.ElementAt(2).AwayTeamName, Is.EqualTo("Team C"));
            Assert.That(result.ElementAt(2).HomeTeamName, Is.EqualTo("Team D"));

            Assert.That(result.ElementAt(3).Id, Is.EqualTo(10));
            Assert.That(result.ElementAt(3).AwayTeamName, Is.EqualTo("Team A"));
            Assert.That(result.ElementAt(3).HomeTeamName, Is.EqualTo("Team B"));
        }

        [Test]
        public async Task GetAllFootballGamesInAdminAsync_ReturnsMappedViewModels()
        {
            // Arrange
            var footballGames = new List<FootballGame>
        {
            new FootballGame
            {
                Id = 10,
                RefereeName = "John Doe",
                PlayingFor = "Team A vs Team B",
                StartGame = DateTime.Now,
                AwayTeam = new Team { Name = "Team A" },
                HomeTeam = new Team { Name = "Team B" }
            },
            new FootballGame
            {
                Id = 20,
                RefereeName = "Jane Smith",
                PlayingFor = "Team C vs Team D",
                StartGame = DateTime.Now.AddDays(1),
                AwayTeam = new Team { Name = "Team C" },
                HomeTeam = new Team { Name = "Team D" }
            }
        };

            await context.AddRangeAsync(footballGames);
            await context.SaveChangesAsync();
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AllReadOnly<FootballGame>())
                          .Returns(context.FootballGames.AsQueryable());

            var service = new FootballGameService(mockRepository.Object);

            // Act
            var result = await service.GetAllFootballGamesInAdminAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<FootballGameAllViewModel>>(result);
            Assert.That(result.Count(), Is.EqualTo(4));

            // Verify that mappings are correct
            Assert.That(result.ElementAt(2).Id, Is.EqualTo(20));
            Assert.That(result.ElementAt(2).RefereeName, Is.EqualTo("Jane Smith"));
            Assert.That(result.ElementAt(2).PlayingFor, Is.EqualTo("Team C vs Team D"));
            Assert.That(result.ElementAt(2).StartGame, Is.EqualTo(footballGames[1].StartGame.ToString(DataConstants.DateTimeFormat)));
            Assert.That(result.ElementAt(2).AwayTeamName, Is.EqualTo("Team C"));
            Assert.That(result.ElementAt(2).HomeTeamName, Is.EqualTo("Team D"));

            Assert.That(result.ElementAt(3).Id, Is.EqualTo(10));
            Assert.That(result.ElementAt(3).RefereeName, Is.EqualTo("John Doe")); 
            Assert.That(result.ElementAt(3).PlayingFor, Is.EqualTo("Team A vs Team B"));
            Assert.That(result.ElementAt(3).StartGame, Is.EqualTo(footballGames[0].StartGame.ToString(DataConstants.DateTimeFormat)));
            Assert.That(result.ElementAt(3).AwayTeamName, Is.EqualTo("Team A"));
            Assert.That(result.ElementAt(3).HomeTeamName, Is.EqualTo("Team B"));
        }

        [Test]
        public async Task GetFootballDetailsAsync_WithValidId_ReturnsCorrectViewModel()
        {
            // Arrange & Act
            repository = new Repository(context);
            fbService = new FootballGameService(repository);

            var result = await fbService.GetFootballDetailsAsync(3);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(3));
            Assert.That(result.PlayingFor, Is.EqualTo("Premier League Test"));
            Assert.That(result.StartGame, Is.EqualTo("01.01.2025 17:00"));
            Assert.That(result.RefereeName, Is.EqualTo("Test Testing"));
            Assert.That(result.AwayTeamName, Is.EqualTo("testAway"));
            Assert.That(result.HomeTeamName, Is.EqualTo("testHome"));
            Assert.That(result.AwayTeamId, Is.EqualTo(5));
            Assert.That(result.HomeTeamId, Is.EqualTo(6));
        }

        public void TearDown()
        {
            context.Dispose();
        }
    }
}
