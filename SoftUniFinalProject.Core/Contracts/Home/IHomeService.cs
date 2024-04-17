namespace SoftUniFinalProject.Core.Contracts.Home
{
    public interface IHomeService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
