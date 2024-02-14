using Notifications.Domain.Enums;

namespace Notifications.Domain.Models
{
    /// <summary>
    /// Модель для логов электронных писем.
    /// </summary>
    public class EmailLogModel
    {
        /// <summary>
        /// Уникальный идентификатор лога электронного письма.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Электронный адрес отправителя.
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// Тема электронного письма.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Тело электронного письма.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Адресата электронного письма.
        /// </summary>
        public string RecipientEmail { get; set; }

        /// <summary>
        /// Статус лога электронного письма.
        /// </summary>
        public LogStatus Status { get; set; }
    }
}
