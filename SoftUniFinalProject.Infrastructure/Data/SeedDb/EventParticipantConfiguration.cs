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
    internal class EventParticipantConfiguration : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            builder.HasKey(ep => new { ep.EventId, ep.UserId });

            builder
                .HasOne(ep => ep.Event)
                .WithMany(ep => ep.EventParticipants)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new EventParticipant { EventId = 1, UserId = "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e" });
        }
    }
}
