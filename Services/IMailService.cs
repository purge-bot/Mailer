namespace Mailer.Services
{
    public interface IMailService
    {
        /// <summary>
        /// Выполнить отправку email сообщения.
        /// </summary>
        /// <param name="ToEmails">Список получателей.</param>
        /// <param name="subject">Заголовк сообщения.</param>
        /// <param name="body">Тело сообщения.</param>
        public Task SendMsgTo(List<string> ToEmails, string subject, string body);
    }
}
