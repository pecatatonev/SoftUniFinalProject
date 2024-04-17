using SoftUniFinalProject.Core.Contracts.Admin.Identity;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;

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
