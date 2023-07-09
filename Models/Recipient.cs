namespace Mailer.Models
{
    public class Recipient
    {
        /// <summary>
        /// Уникальный идетификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Email получателя.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Список запросов.
        /// </summary>
        public ICollection<Request> Request { get; set; }
    }
}
