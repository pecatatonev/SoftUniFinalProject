namespace SoftUniFinalProject.Core.Models.Event
{
    public class EventAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string StartOn { get; set; } = string.Empty;
        public string Organiser { get; set; } = string.Empty;
        public int FootballGameId { get; set; }
    }
}
