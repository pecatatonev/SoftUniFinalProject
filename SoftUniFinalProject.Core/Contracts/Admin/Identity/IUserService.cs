using SoftUniFinalProject.Infrastructure.Data.IdentityModels;

namespace SoftUniFinalProject.Core.Contracts.Admin.Identity
{
    public interface IUserService
    {
        public ApplicationRole RoleCreate(string roleName);
    }
}
