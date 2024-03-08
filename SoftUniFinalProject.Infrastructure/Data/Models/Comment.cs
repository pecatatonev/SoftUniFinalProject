using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniFinalProject.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        [Comment("Comment Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.Comment.TextMaxLenght)]
        [Comment("Text of the comment")]
        public string Text { get; set; } = string.Empty;
        [Comment("The publication time of the comment")]
        public DateTime PublicationTime { get ; set; } = DateTime.Now;
        [Comment("Event Identifier")]
        public int EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        [Comment("Event to comment")]
        public Event Event { get; set; } = null!;
        [Comment("Creator of the comment Identifier")]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [Comment("Creator of the comment")]
        public IdentityUser User { get; set; } = null!;
    }
}
