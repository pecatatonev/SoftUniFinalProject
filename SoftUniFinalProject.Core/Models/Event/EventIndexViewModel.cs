using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Models.Event
{
    public class EventIndexViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string StartOn { get; set; } = string.Empty;
        public string FootballGame { get; set; } = string.Empty;
    }
}
