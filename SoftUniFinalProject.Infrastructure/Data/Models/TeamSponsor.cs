using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniFinalProject.Infrastructure.Data.Models
{
    public class TeamSponsor
    {
        [Comment("Team Sponsor Identifier")]
        public int SponsorId { get; set; }
        [ForeignKey(nameof(SponsorId))]
        [Comment("Team Sponsor")]
        public Sponsor Sponsor { get; set; } 
        [Comment("Team Identifier")]
        public int TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        [Comment("Team")]
        public Team Team { get; set; } 
    }
}
