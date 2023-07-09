using Mailer.Models;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        /// <summary>
        /// Сохранение в базу данных начальных данных Result.
        /// </summary>
        /// <param name="service">Сервис для извлечения констекста базы данных.</param>
        public static void InsertToResult(IServiceProvider service)
        {
            var context = service.GetRequiredService<IMailRepository>().Context;
            if (context.Result.Count() == 0)
            {
                List<Result> results = new List<Result>()
                {
                    new Result{ Name = "Ok"},
                    new Result{Name = "Fail"}
                };
                context.AddRange(results);
            }
            context.SaveChanges();
        }
        /// <summary>
        /// Сообщения об ошибке.
        /// </summary>
        public DbSet<FailedMessage> FailedMessage { get; set; }
        /// <summary>
        /// Сообщения.
        /// </summary>
        public DbSet<Message> Message { get; set; }
        /// <summary>
        /// Получатели.
        /// </summary>
        public DbSet<Recipient> Recipient { get; set; }
        /// <summary>
        /// Результаты отправки сообщения.
        /// </summary>
        public DbSet<Result> Result { get; set; }
        /// <summary>
        /// Отправители.
        /// </summary>
        public DbSet<Sender> Sender { get; set; }
        /// <summary>
        /// Запросы.
        /// </summary>
        public DbSet<Request> Request { get; set; }
    }
}
