using System.ComponentModel.DataAnnotations;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Sponsor;

namespace SoftUniFinalProject.Core.Models.Team
{
    public class SponsorServiceViewModel
    {
        public string Name { get; set; } = string.Empty;
        public int NetWorthInBillion { get; set; }
        public string StartOn { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
