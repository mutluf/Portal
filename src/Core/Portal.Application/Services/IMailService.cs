namespace Portal.Application.Services
{
    public interface IMailService
    {
        public Task SendMail(string[] tos, string subject, string body, bool isBodyHtml = true);
    }
}
