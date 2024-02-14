using MimeKit;
using Notifications.Domain.Models.Email;

namespace Notifications.BL.Helpers
{
    /// <summary>
    /// Вспомогательный класс для работы с отправкой электронных писем.
    /// </summary>
    public static class EmailSenderHelper
    {
        /// <summary>
        /// Создание электронного письма с данными.
        /// </summary>
        /// <param name="recipientEmail">Адрес получателя.</param>
        /// <param name="subject">Тема письма.</param>
        /// <param name="body">Текст письма.</param>
        /// <param name="emailSettings">Настройки электронной почты.</param>
        /// <returns>Объект <see cref="MimeMessage"/> с установленными данными.</returns>
        public static MimeMessage CreateMessage(string recipientEmail, string subject, string body, EmailSettings emailSettings)
        {
            var message = new MimeMessage
            {
                Date = DateTime.UtcNow,
                Subject = subject,
                Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = body
                },
                MessageId = Guid.NewGuid().ToString(),
                Priority = MessagePriority.Normal
            };
            message.From.Add(MailboxAddress.Parse(emailSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Headers.Add("List-Unsubscribe", string.Empty);
            message.Headers.Add("Precedence", "bulk");
            return message;
        }
    }
}
