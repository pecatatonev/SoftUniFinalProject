namespace SoftUniFinalProject.Core.Models.Team
{
    public class SponsorServiceViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public int NetWorthInBillion { get; set; }
        public int YearCreated { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
