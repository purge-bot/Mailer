namespace Mailer.Models
{
    public class Sender
    {
        /// <summary>
        /// Уникальный идетификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Email отправителя.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Список запросов.
        /// </summary>
        public ICollection<Request> Request { get; set; }
    }
}
