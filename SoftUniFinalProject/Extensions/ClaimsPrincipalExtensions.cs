using Microsoft.AspNetCore.Server.IIS.Core;
using System.Security.Claims;

namespace SoftUniFinalProject.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user) 
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
