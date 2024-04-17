using SoftUniFinalProject.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace SoftUniFinalProject.Core.Models.Admin
{
    public class RoleAddViewModel
    {
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public string RoleName { get; set; } = string.Empty;
    }
}
