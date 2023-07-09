using Mailer.Models;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Repository
{
    public class MailRepository : IMailRepository
    {
        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        public AppDbContext Context { get; }
        public MailRepository(AppDbContext ctx)
        {
            Context = ctx;
        }
        /// <summary>
        /// Сообщения об ошибке.
        /// </summary>
        public IQueryable<FailedMessage> FailedMessage => Context.FailedMessage;
        /// <summary>
        /// Сообщения.
        /// </summary>
        public IQueryable<Message> Message => Context.Message;
        /// <summary>
        /// Получатели.
        /// </summary>
        public IQueryable<Recipient> Recipient => Context.Recipient;
        /// <summary>
        /// Результаты отправки сообщения.
        /// </summary>
        public IQueryable<Result> Result => Context.Result;
        /// <summary>
        /// Отправители.
        /// </summary>
        public IQueryable<Sender> Sender => Context.Sender;
        /// <summary>
        /// Запросы.
        /// </summary>
        public IQueryable<Request> Request => Context.Request;
    }
}