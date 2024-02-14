namespace Notifications.Domain.Models.Email
{
    /// <summary>
    /// Модель настроек электронной почты.
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// Электронный адрес отправителя.
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// SMTP-хост для отправки электронных писем.
        /// </summary>
        public string SmtpHost { get; set; }

        /// <summary>
        /// Защищенный порт для отправки электронных писем.
        /// </summary>
        public int SecuredPort { get; set; }

        /// <summary>
        /// Пароль для доступа к учетной записи электронной почты отправителя.
        /// </summary>
        public string Password { get; set; }
    }
}
