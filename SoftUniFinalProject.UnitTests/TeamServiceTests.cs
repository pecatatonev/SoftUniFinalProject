using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Services.EventService;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data;
using SoftUniFinalProject.Infrastructure.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using SoftUniFinalProject.Infrastructure.Data.Models;
using SoftUniFinalProject.Core.Services.TeamService;
using Moq;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Core.Models.Event;

namespace SoftUniFinalProject.UnitTests
{
    [TestFixture]
    public class TeamServiceTests
    {
        private IRepository repository;
        private ITeamService teamService;
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
            context.Teams.AddRange(new List<Team>
            {
                new Team { Id = 100,
                ManagerName = "TestM",
                ImageUrl = "",
                Name = "Test",
                Nickname = "TestN",
                StadiumCapacity = 1000,
                StadiumName = "TestS",
                YearOfCreation = 1989
                },
                new Team{ Id = 101,
                ManagerName = "TestM 2",
                ImageUrl = "",
                Name = "Test 2",
                Nickname = "TestN 2",
                StadiumCapacity = 10001,
                StadiumName = "TestS 2",
                YearOfCreation = 1990
                }
            });



            context.SaveChanges();
            repository = new Repository(context);
            teamService = new TeamService(repository);
        }

        [Test]
        public async Task AllSortingAsync_ReturnsExpectedResult()
        {
            // Act
            var result = await teamService.AllSortingAsync(searchTerm: "Test", sorting: TeamSorting.CapacityStadium, currentPage: 1, eventPerPage: 2);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Teams.Count(), Is.EqualTo(2));
            Assert.That(result.TotalTeamsCount, Is.EqualTo(2));
        }

        [Test]
        public async Task CreateAsync_NewTeam_SuccessfullyCreatesTeam()
        {
            // Arrange
            var model = await teamService.CreateAsync(new AddTeamViewModel
            {
                Name = "Test Team",
                ManagerName = "Test Manager",
                Nickname = "Test Nickname",
                StadiumCapacity = 50000,
                YearOfCreation = 2000,
                ImageUrl = "test-image-url",
                StadiumName = "Test Stadium",
                SelectedSponsors = new List<int> { 1, 2, 3 } // Example sponsor IDs
            });

            var dbTeam = await repository.GetByIdAsync<Team>(102);
            // Act & Assert
            Assert.That(dbTeam.Id, Is.EqualTo(102));
            Assert.That(dbTeam.ManagerName, Is.EqualTo("Test Manager"));
            Assert.That(dbTeam.Name, Is.EqualTo("Test Team"));
            Assert.That(dbTeam.Nickname, Is.EqualTo("Test Nickname"));
        }

        [Test]
        public async Task GetTeamDetailsAsync_WithValidId_ReturnsCorrectViewModel()
        {
            //Arrange & Act
            var result = await teamService.GetTeamDetailsAsync(100);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(100));
            Assert.That(result.ManagerName, Is.EqualTo("TestM"));
            Assert.That(result.Name, Is.EqualTo("Test"));
            Assert.That(result.StadiumCapacity, Is.EqualTo(1000));
            Assert.That(result.StadiumName, Is.EqualTo("TestS"));
            Assert.That(result.ImageUrl, Is.EqualTo(""));
            Assert.That(result.Nickname, Is.EqualTo("TestN"));
            Assert.That(result.YearOfCreation, Is.EqualTo(1989));
        }

        [Test]
        public async Task GetAllTeamsAsync_ReturnsMappedViewModels()
        {
            // Arrange
            var result = await teamService.GetAllTeamsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(context.Teams.Count()));

            foreach (var team in result)
            {
                var teamViewModel = result.FirstOrDefault(t => t.Id == team.Id && t.Name == team.Name);
                Assert.IsNotNull(teamViewModel);
            }
        }

        [Test]
        public async Task GetAllTeamsForSponsorAsync_ReturnsMappedViewModels()
        {
            // Arrange
            var result = await teamService.GetAllTeamsForSponsorAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(context.Teams.Count()));

            foreach (var team in result)
            {
                var teamViewModel = result.FirstOrDefault(t => t.Id == team.Id && t.Name == team.Name);
                Assert.IsNotNull(teamViewModel);
            }
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
