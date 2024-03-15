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
    public class AddTeamViewModel
    {
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [Range(YearCreatedMin, YearCreatedMax, ErrorMessage = DataConstants.LenghtIntegerMessage)]
        public int YearOfCreation { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(ManagerNameMaxLenght, MinimumLength = ManagerNameMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string ManagerName { get; set; } = string.Empty;
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(StadiumMaxLenght, MinimumLength = StadiumMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string StadiumName { get; set; } = string.Empty;
        [StringLength(NicknameMaxLenght, MinimumLength = NicknameMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string? Nickname { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [Range(StadiumCapacityMin, StadiumCapacityMax, ErrorMessage = DataConstants.LenghtIntegerMessage)]
        public int StadiumCapacity { get; set; }
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        [Display(Name = "Sponsors")]
        public int SponsorId { get; set; }
        public IEnumerable<SponsorServiceViewModel> Sponsors { get; set; } = new List<SponsorServiceViewModel>();
    }
}
