using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniFinalProject.Infrastructure.Constants;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.FootballGame;
using System.Runtime.CompilerServices;
using SoftUniFinalProject.Core.Models.Team;

namespace SoftUniFinalProject.Core.Models.Event
{
    public class AddFootballGameViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(PlayingForMaxLenght, MinimumLength = PlayingForMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string PlayingFor { get; set; } = string.Empty;
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public int HomeTeamId { get; set; }
        public IEnumerable<AddTeamToFootballGameViewModel> HomeTeams { get; set; } = new List<AddTeamToFootballGameViewModel>();
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public int AwayTeamId { get; set; }
        public IEnumerable<AddTeamToFootballGameViewModel> AwayTeams { get; set; } = new List<AddTeamToFootballGameViewModel>();
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(RefereeNameMaxLenght, MinimumLength = RefereeNameMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string RefereeName { get; set; } = string.Empty;
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public string StartGame { get; set; } = string.Empty;
    }
}
