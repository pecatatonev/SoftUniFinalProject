using SoftUniFinalProject.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Comment;

namespace SoftUniFinalProject.Core.Models.Comment
{
    public class CommentToCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(TextMaxLenght, MinimumLength = TextMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string Text { get; set; } = string.Empty;
        public int EventId { get; set; }
    }
}
