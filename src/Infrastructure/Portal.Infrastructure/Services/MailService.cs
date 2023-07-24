using Microsoft.Extensions.Configuration;
using Portal.Application.Services;
using System.Net;
using System.Net.Mail;

namespace FloraAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMail(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new MailMessage();

            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
            {
                mail.To.Add(to);
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress(_configuration["Mail:Username"],"deneme",System.Text.Encoding.UTF8);
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = "smtp.gmail.com";
            await smtp.SendMailAsync(mail);

        }
        
    }
}
