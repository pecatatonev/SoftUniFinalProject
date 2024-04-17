namespace SoftUniFinalProject.Core.Models.Event
{
    public class EventQueryServiceModel
    {
        public int TotalEventCount { get; set; }

        public IEnumerable<EventAllViewModel> Events { get; set; } = new List<EventAllViewModel>();
    }
}
