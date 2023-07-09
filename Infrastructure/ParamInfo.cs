namespace Mailer.Infrastructure
{
    public class ParamInfo
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Тело сообщения.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Список получателей.
        /// </summary>
        public string[] Recipients { get; set; }
    }
}
