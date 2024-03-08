using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Event;

namespace SoftUniFinalProject.Infrastructure.Data.Models
{
    public class Event
    {
        [Key]
        [Comment("Event Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("Event Name")]
        public string Name { get; set; } = string.Empty;
        [Comment("Event Description")]
        [MaxLength(DescriptionMaxLenght)]
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(LocationNameMaxLenght)]
        [Comment("Event Location")]
        public string Location { get; set; } = string.Empty;
        [Required]
        [Comment("Start of the event")]
        public DateTime StartOn { get; set; }
        [Required]
        [Comment("Organiser Identifier")]
        public int OrganiserId { get; set; }
        [ForeignKey(nameof(OrganiserId))]
        [Comment("Organiser of the event")]
        public IdentityUser Organiser { get; set; } = null!;
        [Required]
        [Comment("Football game Identifier")]
        public int FootballGameId { get; set; }
        [ForeignKey(nameof(FootballGameId))]
        [Comment("Football game to watch")]
        public FootballGame FootballGame { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
    }
}
