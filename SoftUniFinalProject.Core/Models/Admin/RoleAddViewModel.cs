using SoftUniFinalProject.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Models.Admin
{
    public class RoleAddViewModel
    {
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public string RoleName { get; set; } = string.Empty;
    }
}
