namespace SoftUniFinalProject.Core.Models.Comment
{
    public class CommentDeleteViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string PublicationTime { get; set; } = string.Empty;
        public int EventId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
