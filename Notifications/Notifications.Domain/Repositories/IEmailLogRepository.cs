using Notifications.Domain.Entities;
using Notifications.Domain.Models;

namespace Notifications.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с логами электронных писем.
    /// </summary>
    public interface IEmailLogRepository
    {
        // <summary>
        /// Асинхронно добавляет логи электронных писем в базу данных.
        /// </summary>
        /// <param name="emailLogs">Коллекция логов электронных писем.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Задача, представляющая асинхронное выполнение операции.</returns>
        Task AddEmailsLogsAsync(IEnumerable<EmailLog> emailLogs, CancellationToken cancellationToken);

        /// <summary>
        /// Асинхронно получает логи электронных писем из базы данных.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Массив моделей логов электронных писем.</returns>
        Task<EmailLogModel[]> GetEmailLogsAsync(CancellationToken cancellationToken);
    }
}
