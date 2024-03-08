using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Infrastructure.Data.Models
{
    public class TeamSponsor
    {
        public int SponsorId { get; set; }
        [ForeignKey(nameof(SponsorId))]
        public Sponsor Sponsor { get; set; } = null!;

        public int TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;
    }
}
