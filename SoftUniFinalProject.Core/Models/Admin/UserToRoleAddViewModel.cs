using SoftUniFinalProject.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace SoftUniFinalProject.Core.Models.Admin
{
    public class UserToRoleAddViewModel
    {
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public string UserId { get; set; } = string.Empty;
        public ICollection<UsersViewModel> Users { get; set; } = new List<UsersViewModel>();
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public string RoleId { get; set; } = string.Empty;
        public ICollection<RoleListViewModel> Roles { get; set; } = new List<RoleListViewModel>();
    }
}
