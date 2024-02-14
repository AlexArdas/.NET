using MediatR;

namespace Notifications.BL.MediatR.Commands
{
    /// <summary>
    /// Команда для отправки электронных писем.
    /// </summary>
    public class SendEmailsCommand : IRequest
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
        /// Массив адресов получателей электронного письма.
        /// </summary>
        public string[] Recipients { get; set; }
    }
}
