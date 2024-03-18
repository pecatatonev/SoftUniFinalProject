using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Models.Event
{
    public class FootballGameViewModel
    {
        public int Id { get; set; }
        public string PlayingFor { get; set; } = string.Empty;
        public string HomeTeamName { get; set; } = string.Empty;
        public string AwayTeamName { get; set; } = string.Empty;
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string RefereeName { get; set; } = string.Empty;
        public string StartGame { get; set; } = string.Empty;
    }
}
