using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Contracts.Home
{
    public interface IHomeService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
