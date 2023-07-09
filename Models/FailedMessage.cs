namespace Mailer.Models
{
    public class FailedMessage
    {
        /// <summary>
        /// Уникальный идетификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Список отправленных запросов.
        /// </summary>
        public ICollection<Request> Request { get; set; }
    }
}
