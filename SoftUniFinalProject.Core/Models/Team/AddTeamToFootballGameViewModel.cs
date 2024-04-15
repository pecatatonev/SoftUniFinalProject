using SoftUniFinalProject.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Models.Team
{
    public class AddTeamToFootballGameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
