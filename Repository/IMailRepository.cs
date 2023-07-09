using Mailer.Models;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Repository
{
    public interface IMailRepository
    {
        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        public AppDbContext Context { get; }
        /// <summary>
        /// Сообщения об ошибке.
        /// </summary>
        public IQueryable<FailedMessage> FailedMessage { get; }
        /// <summary>
        /// Сообщения.
        /// </summary>
        public IQueryable<Message> Message { get; }
        /// <summary>
        /// Получатели.
        /// </summary>
        public IQueryable<Recipient> Recipient { get; }
        /// <summary>
        /// Результаты отправки сообщения.
        /// </summary>
        public IQueryable<Result> Result { get; }
        /// <summary>
        /// Получатели.
        /// </summary>
        public IQueryable<Sender> Sender { get; }
        /// <summary>
        /// Отправители.
        /// </summary>
        public IQueryable<Request> Request { get; }
    }
}