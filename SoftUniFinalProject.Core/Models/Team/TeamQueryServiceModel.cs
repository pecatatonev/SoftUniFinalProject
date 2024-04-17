namespace SoftUniFinalProject.Core.Models.Team
{
    public class TeamQueryServiceModel
    {
        public int TotalTeamsCount { get; set; }

        public IEnumerable<TeamsAllViewModel> Teams { get; set; } = new List<TeamsAllViewModel>();
    }
}
