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
        [StringLength(NameMaxLenght)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Comment("Sponsor NetWorth")]
        [Range(NetWorthMin, NetWorthMax)]
        [Required]
        public int NetWorthInBillion { get; set; }
        [Comment("Date of creation")]
        [Required]
        public DateTime StartOn { get; set; }
        [Comment("Logo of the sponsor")]
        public string ImageUrl { get; set; } = string.Empty;

    }
}
