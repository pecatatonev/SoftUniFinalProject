using SoftUniFinalProject.Core.Contracts.Admin.Identity;
using SoftUniFinalProject.Core.Models.Admin;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Services.Admin.UserService
{
    public class UserService : IUserService
    {
        public ApplicationRole RoleCreate(string roleName)
        {
            var role = new ApplicationRole()
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            };

            return role;
        }
    }
}
