using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Models.Event
{
    public class EventDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string StartOn { get; set; } = string.Empty;
    }
}
