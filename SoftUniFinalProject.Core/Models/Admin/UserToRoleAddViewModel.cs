using SoftUniFinalProject.Infrastructure.Constants;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
