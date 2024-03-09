using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftUniFinalProject.Infrastructure.Data.Models;
using SoftUniFinalProject.Infrastructure.Data.SeedDb;
using System.Reflection.Emit;
using System.Security.Principal;

namespace SoftUniFinalProject.Infrastructure.Data
{
    public class FootballEventDbContext : IdentityDbContext
    {
        public FootballEventDbContext(DbContextOptions<FootballEventDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SponsorConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new FootballGameConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new TeamSponsorConfiguration());
            modelBuilder.ApplyConfiguration(new EventParticipantConfiguration());

            //Za dobavqne kum many to many table
        //    internal class ConfigureAuthorBook : IEntityTypeConfiguration<Book>
        //{
        //    public void Configure(EntityTypeBuilder<Book> entity)
        //    {
        //        entity
        //            .HasMany(b => b.Authors)
        //            .WithMany(a => a.Books)
        //            .UsingEntity(
        //                 ba => ba.HasData(
        //                     new { BooksBookId = 1, AuthorsAuthorId = 1 },
        //                     new { BooksBookId = 1, AuthorsAuthorId = 2 }));
        //    }
        //}
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;
        public DbSet<FootballGame> FootballGames { get; set; } = null!;
        public DbSet<Sponsor> Sponsors { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<TeamSponsor> TeamsSponsors { get; set; } = null!;
    }
}