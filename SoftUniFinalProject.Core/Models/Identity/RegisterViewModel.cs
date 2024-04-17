using SoftUniFinalProject.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.ApplicationUser;

namespace SoftUniFinalProject.Core.Models.Identity
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(FirstNameMaxLenght, MinimumLength = FirstNameMinLenght)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(LastNameMaxLenght, MinimumLength = LastNameMinLenght)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(UserNameMaxLenght, MinimumLength = UserNameMinLenght)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [EmailAddress]
        [StringLength(EmailMaxLenght, MinimumLength = EmailMinLenght)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(PasswordMaxLenght, MinimumLength = PasswordMinLenght)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
