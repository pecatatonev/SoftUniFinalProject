using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Team;

namespace SoftUniFinalProject.Infrastructure.Data.Models
{
    public class Team
    {
        [Key]
        [Comment("Team Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("Team Name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Comment("Creation year of the team")]
        [Range(YearCreatedMin, YearCreatedMax)]
        public int YearOfCreation { get; set; }
        [Required]
        [MaxLength(ManagerNameMaxLenght)]
        [Comment("Manager of the team")]
        public string ManagerName { get; set; } = string.Empty;
        [Required]
        [MaxLength(StadiumMaxLenght)]
        [Comment("Team Stadium Name")]
        public string StadiumName { get; set; } = string.Empty;
        [Comment("Team Nickname")]
        [MaxLength(NicknameMaxLenght)]
        public string? Nickname { get; set; }
        [Required]
        [Comment("Stadium Capacity")]
        public int StadiumCapacity { get; set; }
        [Required]
        [Comment("Team logo")]
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<TeamSponsor> TeamsSponsors { get; set; } = new List<TeamSponsor>();
    }
}
