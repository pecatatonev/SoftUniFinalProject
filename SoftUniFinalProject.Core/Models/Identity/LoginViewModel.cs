using SoftUniFinalProject.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace SoftUniFinalProject.Core.Models.Identity
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
