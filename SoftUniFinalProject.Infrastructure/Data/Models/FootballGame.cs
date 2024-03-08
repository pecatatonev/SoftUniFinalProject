using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.FootballGame;

namespace SoftUniFinalProject.Infrastructure.Data.Models
{
    public class FootballGame
    {
        [Key]
        [Comment("Football Game Identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Reason for the game")]
        public string PlayingFor { get; set; } = string.Empty;
        [Required]
        [Comment("Football Game Home Team Identifier")]
        public int HomeTeamId { get; set; }
        [ForeignKey(nameof(HomeTeamId))]
        [Comment("Football Game Home Team")]
        public Team HomeTeam { get; set; } = null!;
        [Required]
        [Comment("Football Game Away Team Identifier")]
        public int AwayTeamId { get; set; }
        [ForeignKey(nameof(AwayTeamId))]
        [Comment("Football Game Away Team")]
        public Team AwayTeam { get; set; } = null!;
        [Required]
        [Comment("Referee of the match name")]
        [MaxLength(RefereeNameMaxLenght)]
        public string RefereeName { get; set; } = string.Empty;
        [Comment("Start of the game")]
        public DateTime StartGame { get; set; }

    }
}
