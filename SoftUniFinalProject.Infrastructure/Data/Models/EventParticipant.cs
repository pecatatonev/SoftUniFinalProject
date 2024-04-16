using Microsoft.AspNetCore.Identity;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Infrastructure.Data.Models
{
    public class EventParticipant
    {
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
        public int EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }
    }
}
