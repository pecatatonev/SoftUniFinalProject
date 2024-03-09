using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Infrastructure.Data.SeedDb
{
    internal class FootballGameConfiguration : IEntityTypeConfiguration<FootballGame>
    {
        public void Configure(EntityTypeBuilder<FootballGame> builder)
        {

            builder.HasOne(fb => fb.AwayTeam)
                 .WithOne().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fb => fb.HomeTeam)
                 .WithOne().OnDelete(DeleteBehavior.NoAction);

            var data = new SeedData();

            builder.HasData(new FootballGame[] { data.ManUvsLiv });
        }
    }
}
