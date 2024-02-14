namespace Notifications.WebAPI.Models.Request
{
    /// <summary>
    /// Модель запроса для отправки электронных писем.
    /// </summary>
    public class SendEmailsRequest
    {
        /// <summary>
        /// Тема электронного письма.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Тело электронного письма.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Массив адресатов электронного письма.
        /// </summary>
        public string[] Recipients { get; set; }
    }
}
