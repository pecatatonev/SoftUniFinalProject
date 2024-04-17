namespace SoftUniFinalProject.Core.Models.Event
{
    public class FootballGameAllViewModel
    {
        public int Id { get; set; }
        public string PlayingFor { get; set; } = string.Empty;
        public string HomeTeamName { get; set; } = string.Empty;
        public string AwayTeamName { get; set; } = string.Empty;
        public string RefereeName { get; set; } = string.Empty;
        public string StartGame { get; set; } = string.Empty;
    }
}
