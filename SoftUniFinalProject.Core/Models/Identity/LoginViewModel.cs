using SoftUniFinalProject.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
