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
    internal class TeamSponsorConfiguration : IEntityTypeConfiguration<TeamSponsor>
    {
        public void Configure(EntityTypeBuilder<TeamSponsor> builder)
        {
            builder.HasKey(ts => new { ts.SponsorId, ts.TeamId });

            builder.HasData(new TeamSponsor { SponsorId = 1, TeamId = 1 },
                new TeamSponsor { SponsorId = 2, TeamId = 2 });
        }
    }
}
