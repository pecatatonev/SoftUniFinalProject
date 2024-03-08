using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System.Reflection.Emit;

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

            base.OnModelCreating(modelBuilder);
        }
    }
}