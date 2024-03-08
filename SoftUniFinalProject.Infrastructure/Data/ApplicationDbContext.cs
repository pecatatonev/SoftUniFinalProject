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

            //modelBuilder.Entity<TeamSponsor>()
            //    .HasOne(sp => sp.Team)
            //    .WithMany(sp => sp.TeamsSponsors)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<FootballGame>()
            //    .HasOne(fg => fg.AwayTeam)
            //    .With

            modelBuilder.Entity<EventParticipant>().HasKey(ep => new { ep.EventId, ep.UserId });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Event)
                .WithMany(ep => ep.EventParticipants)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}