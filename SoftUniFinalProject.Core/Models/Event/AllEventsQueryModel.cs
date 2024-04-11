using SoftUniFinalProject.Infrastructure.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Models.Event
{
    public class AllEventsQueryModel
    {
        public int EventsPerPage { get; } = 3;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = string.Empty;

        public EventSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;


        public int TotalEventsCount { get; set; }

        public IEnumerable<EventAllViewModel> Events { get; set; } = new List<EventAllViewModel>();
    }
}
