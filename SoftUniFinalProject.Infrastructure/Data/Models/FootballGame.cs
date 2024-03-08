using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.FootballGame;

namespace SoftUniFinalProject.Infrastructure.Data.Models
{
    public class FootballGame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Comment("Reason for the game")]
        public string PlayingFor { get; set; } = string.Empty;
        [Required]
        public int HomeTeamId { get; set; }
        [ForeignKey(nameof(HomeTeamId))]
        public Team HomeTeam { get; set; } = null!;
        [Required]
        public int AwayTeamId { get; set; }
        [ForeignKey(nameof(AwayTeamId))]
        public Team AwayTeam { get; set; } = null!;
        [Required]
        [Comment("Referee of the match name")]
        [MaxLength(RefereeNameMaxLenght)]
        public string RefereeName { get; set; } = string.Empty;
        [Comment("Start of the game")]
        public DateTime StartGame { get; set; }

    }
}
