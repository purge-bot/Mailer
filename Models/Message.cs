namespace Mailer.Models
{
    public class Message
    {
        /// <summary>
        /// Уникальный идетификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Заголовок сообщения.
        /// </summary>
        public string? Subject { get; set; }
        /// <summary>
        /// Тело сообщения.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Список запросов.
        /// </summary>
        public ICollection<Request> Request { get; set; }
    }
}
