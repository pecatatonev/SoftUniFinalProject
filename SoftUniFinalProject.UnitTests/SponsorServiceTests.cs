﻿using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Models.Team;
using SoftUniFinalProject.Core.Services.TeamService;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data;
using SoftUniFinalProject.Infrastructure.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using SoftUniFinalProject.Infrastructure.Data.Models;
using Moq;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Core.Services.EventService;
using System.Linq.Expressions;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants;
using Sponsor = SoftUniFinalProject.Infrastructure.Data.Models.Sponsor;
using SoftUniFinalProject.Core.Contracts.Event;

namespace SoftUniFinalProject.UnitTests
{
    [TestFixture]
    public class SponsorServiceTests
    {
        private IRepository repository;
        private ISponsorService sponsorService;
        private FootballEventDbContext context;
        private Infrastructure.Data.IdentityModels.ApplicationUser userAdmin;

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
            context.Sponsors.AddRange(new List<Sponsor>()
            {
                new Sponsor()
                {
                    Id = 101,
                    ImageUrl = "",
                    Name = "Test Sponsor",
                    YearCreation = 1903,
                    NetWorthInBillion= 2,
                },
                new Sponsor()
                {
                    Id = 102,
                    ImageUrl = "image-url",
                    Name = "Test Sponsor2",
                    YearCreation = 1905,
                    NetWorthInBillion= 3,
                }
            });
            
            context.SaveChanges();
            repository = new Repository(context);
            sponsorService = new SponsorService(repository);
        }
       
        [Test]
        public async Task CreateAsync_NewTeam_SuccessfullyCreatesSponsor()
        {
            // Arrange
            var model = await sponsorService.CreateAsync(new CreateSponsorViewModel
            {
                Name = "Test create Sponsor",
                ImageUrl = "test-image-url",
                NetWorthInBillion = 2,
                YearCreation = 1900,
                SelectedTeams = new List<int>() {1 , 2 , 3 }
            });

            var dbTeam = await repository.GetByIdAsync<Sponsor>(103);

            // Act & Assert
            Assert.That(dbTeam.Id, Is.EqualTo(103));
            Assert.That(dbTeam.Name, Is.EqualTo("Test create Sponsor"));
            Assert.That(dbTeam.NetWorthInBillion, Is.EqualTo(2));
            Assert.That(dbTeam.YearCreation, Is.EqualTo(1900));
            Assert.That(dbTeam.TeamsSponsors.Count(), Is.EqualTo(3));
        }

        [Test]
        public void CreateAsync_DatabaseException_ThrowsApplicationException()
        {
            // Arrange
            var model = new CreateSponsorViewModel
            {

                Name = "Test create Sponsor",
                ImageUrl = "test-image-url",
                NetWorthInBillion = 2,
                YearCreation = 1900,
                SelectedTeams = new List<int>() { 1, 2, 3 }
            };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AlreadyExistAsync(It.IsAny<Expression<Func<Sponsor, bool>>>()))
              .ReturnsAsync(false);
            mockRepository.Setup(r => r.AddAsync(It.IsAny<TeamSponsor>())).ThrowsAsync(new Exception());
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Sponsor>())).ThrowsAsync(new Exception());

            var service = new SponsorService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<ApplicationException>(() => service.CreateAsync(model));
        }

        [Test]
        public async Task SponsorsByTeamAsync_ReturnsMappedViewModels()
        {
            // Arrange
            int teamId = 8; // Assuming team ID to filter sponsors

            var sponsors = new List<Sponsor>
            {
            new Sponsor { Id = 10, Name = "Sponsor A", ImageUrl = "url1", NetWorthInBillion = 2, YearCreation = 2000 },
            new Sponsor { Id = 11, Name = "Sponsor B", ImageUrl = "url2", NetWorthInBillion = 3, YearCreation = 1995 },
            new Sponsor { Id = 12, Name = "Sponsor C", ImageUrl = "url3", NetWorthInBillion = 4, YearCreation = 2010 }
            };

            var teamSponsors = new List<TeamSponsor>
            {
                new TeamSponsor{ SponsorId = 10, TeamId = 1 },
                new TeamSponsor{ SponsorId = 11, TeamId = 1 },
                new TeamSponsor{ SponsorId = 12, TeamId = 1 }
            };

            var team = new Infrastructure.Data.Models.Team()
            {
                Id = teamId,
                Name = "test",
                TeamsSponsors = teamSponsors
            };

            await repository.AddRangeAsync(sponsors);
            await repository.AddRangeAsync(teamSponsors);
            await repository.AddAsync(team);
            await repository.SaveChangesAsync();
            // Act
            var result = await sponsorService.SponsorsByTeamAsync(teamId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(teamSponsors.Count()));

            foreach (var sponsor in sponsors)
            {
                var sponsorViewModel = result.FirstOrDefault(s => s.Name == sponsor.Name
                                                            && s.ImageUrl == sponsor.ImageUrl
                                                            && s.NetWorthInBillion == sponsor.NetWorthInBillion
                                                            && s.YearCreated == sponsor.YearCreation);
                Assert.IsNotNull(sponsorViewModel);
            }
        }

        [Test]
        public async Task ExistsAsync_SposnorDoesNotExist_ReturnsFalse()
        {
            // Arrange
            int sponsorId = 104;

            // Act
            var result = await sponsorService.SponsorExistAsync(sponsorId);

            // Assert
            Assert.IsFalse(result);
        }


        [Test]
        public async Task ExistsAsync_EventExists_ReturnsTrue()
        {
            // Arrange
            int sponsorId = 101;

            // Act
            var result = await sponsorService.SponsorExistAsync(sponsorId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetAllTeamsAsync_ReturnsMappedViewModels()
        {
            // Arrange
            var result = await sponsorService.AllSponsorsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(context.Sponsors.Count()));

            foreach (var sponsor in result)
            {
                var sponsorViewModel = result.FirstOrDefault(s => s.Id == sponsor.Id
                && s.Name == sponsor.Name
                && s.NetWorthInBillion == sponsor.NetWorthInBillion
                && s.YearCreated == sponsor.YearCreated);

                Assert.IsNotNull(sponsorViewModel);
            }
        }

        [Test]
        public async Task GetAllSponsorsToAddAsync_ReturnsMappedViewModels()
        {
            // Arrange
            var result = await sponsorService.AllSponsorsToAddAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(context.Sponsors.Count()));

            foreach (var sponsor in result)
            {
                var sponsorViewModel = result.FirstOrDefault(s => s.Id == sponsor.Id && s.Name == sponsor.Name);
                Assert.IsNotNull(sponsorViewModel);
            }
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}