using Notifications.Domain.Enums;

namespace Notifications.Domain.Services
{
    /// <summary>
    /// Сервис для отправки электронных писем.
    /// </summary>
    public interface IEmailSenderService
    {
        /// <summary>
        /// Асинхронно отправляет электронное письмо.
        /// </summary>
        /// <param name="email">Адрес получателя.</param>
        /// <param name="subject">Тема письма.</param>
        /// <param name="body">Текст письма.</param>
        /// <returns>Задача, представляющая асинхронное выполнение операции.</returns>
        Task<LogStatus> SendEmailAsync(string email, string subject, string body);
    }
}
