using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System.Reflection.Emit;
using System.Security.Principal;

namespace SoftUniFinalProject.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamSponsor>().HasKey(ts => new { ts.SponsorId, ts.TeamId });

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Event)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FootballGame>().HasOne(fb => fb.AwayTeam)
                 .WithOne().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FootballGame>().HasOne(fb => fb.HomeTeam)
                 .WithOne().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventParticipant>().HasKey(ep => new { ep.EventId, ep.UserId });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Event)
                .WithMany(ep => ep.EventParticipants)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipant> EventsParticipants { get; set; }
        public DbSet<FootballGame> FootballGames { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSponsor> TeamsSponsors { get; set; }
    }
}