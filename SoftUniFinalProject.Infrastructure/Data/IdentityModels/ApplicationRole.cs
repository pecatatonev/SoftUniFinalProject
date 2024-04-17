using Microsoft.AspNetCore.Identity;

namespace SoftUniFinalProject.Infrastructure.Data.IdentityModels
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}
