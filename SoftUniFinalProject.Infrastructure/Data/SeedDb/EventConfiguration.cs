using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftUniFinalProject.Infrastructure.Data.Models;

namespace SoftUniFinalProject.Infrastructure.Data.SeedDb
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            var data = new SeedData();

            builder.HasData(new Event[] { data.WatchEnglishDerby });
        }
    }
}
