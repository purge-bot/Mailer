namespace Mailer.Configuration
{
    public class MailSettings
    {
        /// <summary>
        /// Отправитель сообщений.
        /// </summary>
        public string? From { get; set; }
        /// <summary>
        /// Пароль от почтового ящика.
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// Сервер smpt.
        /// </summary>
        public string? Host { get; set; }
        /// <summary>
        /// Порт сервера smpt.
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Использовать ли ssl (true/false).
        /// </summary>
        public bool UseSSL { get; set; }
        /// <summary>
        /// Является ли сообщение html документом (true/false).
        /// </summary>
        public bool IsBodyHtml { get; set; }
    }
}