using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniFinalProject.Infrastructure.Constants;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Event;
using SoftUniFinalProject.Core.Models.Team;

namespace SoftUniFinalProject.Core.Models.Event
{
    public class AddEventViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(NameMaxLenght,MinimumLength = NameMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(LocationNameMaxLenght, MinimumLength = LocationNameMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string Location { get; set; } = string.Empty;
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        public string StartOn { get; set; } = string.Empty;
        [Display(Name = "Sponsors")]
        public int FootballGameId { get; set; }
        public IEnumerable<FootballGameToAddViewModel> FootballGames { get; set; } = new List<FootballGameToAddViewModel>();
    }
}
