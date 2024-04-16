using Microsoft.AspNetCore.Server.IIS.Core;
using System.Security.Claims;
using static SoftUniFinalProject.Core.Constants.RoleConstants;

namespace SoftUniFinalProject.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user) 
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdministratorRole);
        }
    }
}
