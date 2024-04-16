using SoftUniFinalProject.Core.Models.Admin;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Contracts.Admin.Identity
{
    public interface IUserService
    {
        public ApplicationRole RoleCreate(string roleName);
    }
}
