using System.Net.Mail;
using System.Net;
using Mailer.Configuration;
using Microsoft.Extensions.Options;

namespace Mailer.Services
{
    public class MailService : IMailService
    {
        private MailSettings _settings;
        public MailService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        /// <summary>
        /// Выполнить отправку email сообщения.
        /// </summary>
        /// <param name="ToEmails">Список получателей.</param>
        /// <param name="subject">Заголовк сообщения.</param>
        /// <param name="body">Тело сообщения.</param>
        public async Task SendMsgTo(List<string> ToEmails, string subject, string body)
        {          
            SmtpClient client = new SmtpClient(_settings.Host, 666);
            client.EnableSsl = _settings.UseSSL;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_settings.From, _settings.Password);

            var mailMessage = CreateMessage(ToEmails, subject, body);
            await client.SendMailAsync(mailMessage);
            client.Dispose();
        }
        /// <summary>
        /// Создать сообщение для отправки.
        /// </summary>
        /// <param name="ToEmails">Список получателей.</param>
        /// <param name="subject">Заголовк сообщения.</param>
        /// <param name="body">Тело сообщения.</param>
        /// <returns>MailMessage содержащий информацию о сообщении.</returns>
        private MailMessage CreateMessage(List<string> ToEmails, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_settings.From);
            foreach (var email in ToEmails)
            {
                mailMessage.To.Add(email);
            }
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = _settings.IsBodyHtml;
            mailMessage.Body = body;

            return mailMessage;
        }
    }
}
