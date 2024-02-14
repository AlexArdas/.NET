using FluentValidation;
using MediatR;
using Notifications.BL.MediatR.Commands;
using Notifications.Domain.Entities;
using Notifications.Domain.Models.Email;
using Notifications.Domain.Repositories;
using Notifications.Domain.Services;
using System.Collections.Concurrent;
using System.Text;

namespace Notifications.BL.MediatR.Handlers
{
    /// <summary>
    /// Обработчик команды для отправки электронных писем.
    /// </summary>
    public class SendEmailsHandler : IRequestHandler<SendEmailsCommand>
    {
        private readonly IEmailLogRepository _emailLogRepository;

        private readonly IEmailSenderService _emailSenderService;

        private readonly IValidator<SendEmailsCommand> _sendEmailsCommandvalidator;

        private readonly string _senderEmail;

        /// <summary>
        /// Инициализирует новый экземпляр обработчика команды <see cref="SendEmailsHandler"/>.
        /// </summary>
        /// <param name="emailLogRepository">Репозиторий логов электронных писем.</param>
        /// <param name="emailSenderService">Сервис отправки электронных писем.</param>
        /// <param name="emailSettings">Настройки электронной почты.</param>
        public SendEmailsHandler(IEmailLogRepository emailLogRepository,
            IEmailSenderService emailSenderService,
            IValidator<SendEmailsCommand> sendEmailsCommandvalidator,
            EmailSettings emailSettings)
        {
            _emailLogRepository = emailLogRepository;
            _emailSenderService = emailSenderService;
            _sendEmailsCommandvalidator = sendEmailsCommandvalidator;
            _senderEmail = emailSettings.SenderEmail;
        }

        /// <summary>
        /// Асинхронно обрабатывает команду для отправки электронных писем.
        /// </summary>
        /// <param name="request">Команда для отправки писем.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Задача, представляющая асинхронное выполнение операции.</returns>
        public async Task Handle(SendEmailsCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var validationResult = await _sendEmailsCommandvalidator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessage = new StringBuilder();

                validationResult.Errors.ForEach(error => errorMessage.Append($"{error}. "));

                throw new ValidationException(errorMessage.ToString());
            }
            var emailLogsEntities = new ConcurrentBag<EmailLog>(); //для многопоточного доступа

            var tasks = request.Recipients
                .Select(async recipientEmail =>
                {
                    var logStatus = await _emailSenderService.SendEmailAsync(recipientEmail, request.Subject, request.Body);

                    emailLogsEntities.Add(new EmailLog()
                    {
                        Subject = request.Subject,
                        Body = request.Body,
                        SenderEmail = _senderEmail,
                        RecipientEmail = recipientEmail,
                        Status = logStatus

                    });
                });
            await Task.WhenAll(tasks);
            await _emailLogRepository.AddEmailsLogsAsync(emailLogsEntities, cancellationToken);
        }
    }
}
