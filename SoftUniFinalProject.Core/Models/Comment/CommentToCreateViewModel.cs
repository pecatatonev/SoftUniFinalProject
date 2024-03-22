using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants.Comment;

namespace SoftUniFinalProject.Core.Models.Comment
{
    public class CommentToCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredMessage)]
        [StringLength(TextMaxLenght, MinimumLength = TextMinLenght, ErrorMessage = DataConstants.LenghtMessage)]
        public string Text { get; set; } = string.Empty;
    }
}
