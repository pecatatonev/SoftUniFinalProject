using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Infrastructure.Constants;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Sponsor;

namespace SoftUniFinalProject.Core.Models.Team
{
    public class CreateSponsorViewModel
    {
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public string Name { get; set; } = string.Empty;
        [Range(NetWorthMin, NetWorthMax, ErrorMessage = DataConstants.LenghtIntegerMessage)]
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public int NetWorthInBillion { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [Range(YearCreatedMin, YearCreatedMax, ErrorMessage = DataConstants.LenghtIntegerMessage)]
        public int YearCreation { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public string ImageUrl { get; set; } = string.Empty;
        [Display(Name = "Teams")]
        public IList<int> SelectedTeams { get; set; } = new List<int>();
        public IEnumerable<AddTeamToSponsorViewModel> Teams { get; set; } = new List<AddTeamToSponsorViewModel>();
    }
}
