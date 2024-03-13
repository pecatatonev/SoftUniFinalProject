using System.ComponentModel.DataAnnotations;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Sponsor;

namespace SoftUniFinalProject.Core.Models.Team
{
    public class SponsorServiceViewModel
    {
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = NameLenght)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Range(NetWorthMin, NetWorthMax, ErrorMessage = NetWorthRange)]
        [Required]
        public int NetWorthInBillion { get; set; }
        [Required]
        public string StartOn { get; set; } = string.Empty;
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
