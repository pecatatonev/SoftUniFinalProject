using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Models.Home
{
    public class ContactFormViewModel
    {
        //later make constants

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a message.")]
        public string Message { get; set; } = string.Empty;
    }
}
