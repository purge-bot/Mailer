namespace Mailer.Models
{
    public class Result
    {
        /// <summary>
        /// Уникальный идетификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название результата отправки сообщения.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список запросов.
        /// </summary>
        public ICollection<Request> Request { get; set; }
    }
}
