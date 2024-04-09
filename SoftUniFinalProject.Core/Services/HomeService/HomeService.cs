using SoftUniFinalProject.Core.Contracts.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SoftUniFinalProject.Core.Services.HomeService
{
    public class HomeService : IHomeService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mail = "petpuppshop@gmail.com";
                var pass = "igxw kjdk dzwj jgnp";
                var mailTo = "forworkemail032024@gmail.com";

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                };

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mail, pass);

                await client.SendMailAsync(new MailMessage(from: email,
                    to: mailTo,
                    subject,
                    $"Email Sender: {email} {Environment.NewLine}" +
                    message
                    ));
            }
            catch (Exception ex)
            {
                // Обработка на грешката при изпращане на имейла
                // Например логиране на грешката или обработка на изключението
                throw new ApplicationException("Failed to send email", ex);
            }

        }
    }
}
