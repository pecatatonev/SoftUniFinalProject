using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.ApplicationUser;

namespace SoftUniFinalProject.Infrastructure.Data.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(FirstNameMaxLenght)]
        public string? FirstName { get; set; }
        [MaxLength(LastNameMaxLenght)]
        public string? LastName { get; set;}
    }
}
