namespace Mailer.Models
{
    public class Request
    {
        /// <summary>
        /// Уникальный идетификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Идентификатор сообщения об ошибке.
        /// </summary>
        public int? FailedMessageId { get; set; }
        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public FailedMessage FailedMessage { get; set; }
        /// <summary>
        /// Идентификатор сообщения.
        /// </summary>
        public int? MessageId { get; set; }
        /// <summary>
        /// Сообщение.
        /// </summary>
        public Message Message { get; set; }
        /// <summary>
        /// Идентификатор получателя.
        /// </summary>
        public int? RecipientId { get; set; }
        /// <summary>
        /// Получатель.
        /// </summary>
        public Recipient Recipient { get; set; }
        /// <summary>
        /// Идентификатор результата отправки сообщения.
        /// </summary>
        public int? ResultId { get; set; }
        /// <summary>
        /// Результат отправки сообщения.
        /// </summary>
        public Result Result { get; set; }
        /// <summary>
        /// Идентификатор отправителя.
        /// </summary>
        public int? SenderId { get; set; }
        /// <summary>
        /// Отправитель.
        /// </summary>
        public Sender Sender { get; set; }
    }
}
