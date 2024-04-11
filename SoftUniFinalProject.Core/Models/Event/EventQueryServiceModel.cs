using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Models.Event
{
    public class EventQueryServiceModel
    {
        public int TotalEventCount { get; set; }

        public IEnumerable<EventAllViewModel> Events { get; set; } = new List<EventAllViewModel>();
    }
}
