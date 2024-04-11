using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Infrastructure.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoftUniFinalProject.Core.Models.Team
{
    public class AllTeamsQueryModel
    {
        public int TeamsPerPage { get; } = 3;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = string.Empty;

        public TeamSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalTeamsCount { get; set; }

        public IEnumerable<TeamsAllViewModel> Teams { get; set; } = new List<TeamsAllViewModel>();
    }
}
