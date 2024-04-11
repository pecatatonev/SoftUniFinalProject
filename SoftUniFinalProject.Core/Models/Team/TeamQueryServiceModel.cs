using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Models.Team
{
    public class TeamQueryServiceModel
    {
        public int TotalTeamsCount { get; set; }

        public IEnumerable<TeamsAllViewModel> Teams { get; set; } = new List<TeamsAllViewModel>();
    }
}
