using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Team;

namespace SoftUniFinalProject.Core.Models.Team
{
    public class TeamsAllViewModel
    { 
        public int Id { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [Range(YearCreatedMin, YearCreatedMax, ErrorMessage = DataConstants.LenghtIntegerMessage)]
        [Display(Name = "Creation Year of the club")]
        public int YearOfCreation { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(ManagerNameMaxLenght, MinimumLength = ManagerNameMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; } = string.Empty;
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(StadiumMaxLenght, MinimumLength = StadiumMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        [Display(Name = "Stadium Name")]
        public string StadiumName { get; set; } = string.Empty;
        [StringLength(NicknameMaxLenght, MinimumLength = NicknameMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string? Nickname { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [Range(StadiumCapacityMin, StadiumCapacityMax, ErrorMessage = DataConstants.LenghtIntegerMessage)]
        [Display(Name = "Stadium Capacity")]
        public int StadiumCapacity { get; set; }
        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
