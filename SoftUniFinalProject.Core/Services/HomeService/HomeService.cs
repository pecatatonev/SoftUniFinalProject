using SoftUniFinalProject.Core.Contracts.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using System.Collections;

namespace SoftUniFinalProject.Core.Services.HomeService
{
    public class HomeService : IHomeService
    {
        private readonly IConfiguration _configuration;

        public HomeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetPassword()
        {
            return Environment.GetEnvironmentVariable("MyEmailPass");
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {

                string secretPass = GetPassword();
                var mail = "petpuppshop@gmail.com";
                var mailTo = "forworkemail032024@gmail.com";

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                };

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mail, secretPass);

                await client.SendMailAsync(new MailMessage(from: email,
                    to: mailTo,
                    subject,
                    $"Email Sender: {email} {Environment.NewLine}" +
                    message
                    ));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to send email", ex);
            }

        }
    }
}
