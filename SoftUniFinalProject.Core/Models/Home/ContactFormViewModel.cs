using System.ComponentModel.DataAnnotations;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.ContactForm;

namespace SoftUniFinalProject.Core.Models.Home
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = RequiredEmail)]
        [EmailAddress(ErrorMessage = ValidEmail)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredSubject)]
        public string Message { get; set; } = string.Empty;
    }
}
