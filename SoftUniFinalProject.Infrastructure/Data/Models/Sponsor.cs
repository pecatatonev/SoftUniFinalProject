using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Sponsor;

namespace SoftUniFinalProject.Infrastructure.Data.Models
{
    public class Sponsor
    {
        [Key]
        [Comment("Sponsor Identifier")]
        public int Id { get; set; }
        [Comment("Sponsor Name")]
        [MaxLength(NameMaxLenght)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Comment("Sponsor NetWorth")]
        [Range(NetWorthMin, NetWorthMax)]
        [Required]
        public int NetWorthInBillion { get; set; }
        [Required]
        [Comment("Creation year of the Sponsor")]
        [Range(YearCreatedMin, YearCreatedMax)]
        public int YearCreation { get; set; }
        [Comment("Logo of the sponsor")]
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<TeamSponsor> TeamsSponsors { get; set; } = new List<TeamSponsor>();
    }
}
