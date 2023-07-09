using Mailer.Models;
using Mailer.Repository;

namespace Mailer.Infrastructure
{
    public static class RequestHelper
    {
        /// <summary>
        /// Добавление данных запроса в контекст. После использования необходимо применить SaveChanges().
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        /// <param name="emailsWithError">Словарь почтовых адресов и ошибок.</param>
        /// <param name="resultName">Результат отправки сообщения.</param>
        /// <param name="msg">Класс представляющий сообщение.</param>
        public static void InsertData(IMailRepository repository, Dictionary<string, string> emailsWithError, string resultName, Message msg)
        {
            foreach (var item in emailsWithError)
            {
                var rec = repository.Recipient.FirstOrDefault(p => p.Email == item.Key);
                if (rec == null)
                {
                    rec = new Recipient() { Email = item.Key };
                    repository.Context.Add(rec);
                }

                var result = repository.Result.FirstOrDefault(p => p.Name == resultName);
                var failedMessage = repository.FailedMessage.FirstOrDefault(p => p.Message == item.Value);
                if (failedMessage == null)
                {
                    failedMessage = new FailedMessage() { Message = item.Value };
                    repository.Context.Add(failedMessage);
                }
                Request request = new Request() { CreateDate = DateTime.Now, Message = msg, Recipient = rec, FailedMessage = failedMessage, Result = result };
                repository.Context.Add(request);
            }
        }
    }
}
