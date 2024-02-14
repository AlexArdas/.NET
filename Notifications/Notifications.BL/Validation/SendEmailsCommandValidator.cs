using FluentValidation;
using Notifications.BL.MediatR.Commands;

namespace Notifications.BL.Validation
{
    /// <summary>
    /// Валидатор команды <see cref="SendEmailsCommand"/>
    /// </summary>
    public class SendEmailsCommandValidator : AbstractValidator<SendEmailsCommand>
    {
        /// <summary>
        /// Инициализация экземпляра класса <see cref="SendEmailsCommandValidator"/>
        /// </summary>
        public SendEmailsCommandValidator()
        {
            RuleFor(x => x.Body)
                .NotEmpty()
                .WithMessage("Тело сообщения не должно быть пустым");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .WithMessage("Заголовок сообщения не должен быть пустым");

            RuleForEach(x => x.Recipients)
                .EmailAddress()
                .WithMessage("Адресса почт не должны быть пустыми");
        }
    }
}
