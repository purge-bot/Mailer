namespace Mailer.Infrastructure
{
    public class DataInstance
    {
        /// <summary>
        /// Дата отправки сообщения.
        /// </summary>
        public string SendDate { get; set; }
        /// <summary>
        /// Получатель.
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// Результат отправки сообщения.
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string FailedMessage { get; set; }
        /// <summary>
        /// Заголовок сообщения.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Тело сообщения.
        /// </summary>
        public string Body { get; set; }
    }
}
