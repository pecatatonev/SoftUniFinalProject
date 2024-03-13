using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Team;

namespace SoftUniFinalProject.Core.Models.Team
{
    public class TeamsAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string YearCreated { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public string StadiumName { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public int StadiumCapacity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
