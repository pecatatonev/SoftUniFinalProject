using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using static SoftUniFinalProject.Core.Constants.RoleConstants;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminstratorRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdministratorRole) == false)
            {
                var role = new ApplicationRole(AdministratorRole);
                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync("host@football.com");

                if (admin != null) 
                {
                    await userManager.AddToRoleAsync(admin, role.Name);
                }
            }
        }
    }
}
