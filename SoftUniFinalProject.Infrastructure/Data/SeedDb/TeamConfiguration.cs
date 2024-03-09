using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftUniFinalProject.Infrastructure.Data.Models;

namespace SoftUniFinalProject.Infrastructure.Data.SeedDb
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            var data = new SeedData();

            builder.HasData(new Team[] { data.ManchesterUnited, data.Liverpool });
        }
    }
}
