using Microsoft.AspNetCore.Identity;
using SoftUniFinalProject.Infrastructure.Data.Models;

namespace SoftUniFinalProject.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUser HostUser { get; set; }
        public IdentityUser GuestUser { get; set; }
        public Sponsor AddidasSponsor { get; set; }
        public Sponsor NikeSponsor { get; set; }
        public Team ManchesterUnited { get; set; }
        public Team Liverpool { get; set; }
        public FootballGame ManUvsLiv { get; set; }
        public Event WatchEnglishDerby { get; set; }
        public Comment CommentGuest { get; set; }

        public SeedData() 
        {
            SeedUsers();
            SeedSponsor();
            SeedTeam();
            SeedFootballGame();
            SeedEvent();
            SeedComment();
        }

        private void SeedUsers() 
        {
            var hasher = new PasswordHasher<IdentityUser>();

            HostUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "host@football.com",
                NormalizedUserName = "host@football.com",
                Email = "host@football.com",
                NormalizedEmail = "host@football.com"
            };

            HostUser.PasswordHash = hasher.HashPassword(HostUser, "host123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                UserName = "guest@football.com",
                NormalizedUserName = "guest@football.com",
                Email = "guest@football.com",
                NormalizedEmail = "guest@football.com"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest987");
        }

        private void SeedSponsor() 
        {
            AddidasSponsor = new Sponsor()
            {
                Id = 1,
                Name = "Addidas",
                NetWorthInBillion = 5,
                StartOn = DateTime.Now.AddYears(-20),
                ImageUrl = "https://cdn.britannica.com/94/193794-050-0FB7060D/Adidas-logo.jpg"
            };

            NikeSponsor = new Sponsor()
            {
                Id=2,
                Name = "Nike",
                NetWorthInBillion = 6,
                StartOn = DateTime.Now.AddYears(-23),
                ImageUrl = "https://cdn.shopify.com/s/files/1/0558/6413/1764/files/Rewrite_Nike_Logo_Design_History_Evolution_0_1024x1024.jpg?v=1695304464"
            };
        }

        private void SeedTeam() 
        {
            ManchesterUnited = new Team()
            {
                Id = 1,
                Name = "Manchester United F.C",
                YearCreated = new DateTime(int.Parse("1887"), 1, 1),
                ManagerName = "Erik ten Hag",
                StadiumName = "Old Trafford",
                Nickname = "Red Devils",
                StadiumCapacity = 78000,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7a/Manchester_United_FC_crest.svg/1200px-Manchester_United_FC_crest.svg.png",
            };

            Liverpool = new Team()
            {
                Id = 2,
                Name = "Liverpool F.C",
                YearCreated = new DateTime(int.Parse("1897"), 1, 1),
                ManagerName = "Jurgen Kloop",
                StadiumName = "Anfield",
                Nickname = "The Reds",
                StadiumCapacity = 60730,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/0/0c/Liverpool_FC.svg/1200px-Liverpool_FC.svg.png",
            };
        }

        private void SeedFootballGame() 
        {
            ManUvsLiv = new FootballGame()
            {
                Id = 1,
                RefereeName = "Mike Dean",
                StartGame =new DateTime(2024, 04, 14, 18, 0, 0), //"14.04.2024 18:00:00"
                HomeTeamId = 1,
                AwayTeamId = 2
            };
        }
        private void SeedEvent() 
        {
            WatchEnglishDerby = new Event()
            {
                Id = 1,
                Name = "Biggest English Derby",
                Description = "This is oldest and biggest derby in England Premier League",
                Location = "The Corner Cafe",
                StartOn = new DateTime(2024, 04, 14, 17, 0, 0), //"14.04.2024 17:00:00"
                FootballGameId = 1,
                OrganiserId = "dea12856-c198-4129-b3f3-b893d8395082",
            };
        }
        private void SeedComment() 
        {
            CommentGuest = new Comment()
            {
                Id = 1,
                Text = "I can't wait for that derby",
                PublicationTime = DateTime.Now.AddHours(3),
                EventId = 1,
                UserId = "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e"
            };
        }
    }
}
