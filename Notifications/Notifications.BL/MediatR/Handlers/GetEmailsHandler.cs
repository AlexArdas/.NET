using MediatR;
using Notifications.BL.MediatR.Queries;
using Notifications.Domain.Models;
using Notifications.Domain.Repositories;

namespace Notifications.BL.MediatR.Handlers
{
    /// <summary>
    /// Обработчик запроса для получения логов электронных писем.
    /// </summary>
    public class GetEmailsHandler : IRequestHandler<GetEmailsQuery, EmailLogModel[]>
    {
        private readonly IEmailLogRepository _emailLogRepository;

        /// <summary>
        /// Инициализирует новый экземпляр обработчика запроса <see cref="GetEmailsHandler"/>.
        /// </summary>
        /// <param name="emailLogRepository">Репозиторий логов электронных писем.</param>
        public GetEmailsHandler(IEmailLogRepository emailLogRepository)
        {
            _emailLogRepository = emailLogRepository;
        }

        /// <summary>
        /// Асинхронно обрабатывает запрос для получения логов электронных писем.
        /// </summary>
        /// <param name="request">Запрос на получение логов электронных писем.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Массив моделей логов электронных писем.</returns>
        public async Task<EmailLogModel[]> Handle(GetEmailsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _emailLogRepository.GetEmailLogsAsync(cancellationToken);
        }
    }
}
