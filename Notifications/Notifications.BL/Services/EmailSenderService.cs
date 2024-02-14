using MailKit;
using Notifications.BL.Helpers;
using Notifications.Domain.Enums;
using Notifications.Domain.Models.Email;
using Notifications.Domain.Services;

namespace Notifications.BL.Services
{
    /// <summary>
    /// Сервис для отправки электронных писем.
    /// </summary>
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailSettings _emailSettings;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса <see cref="EmailSenderService"/>.
        /// </summary>
        /// <param name="emailSettings">Настройки электронной почты.</param>
        public EmailSenderService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        /// <inheritdoc/>
        public async Task<LogStatus> SendEmailAsync(string recipientEmail, string subject, string body)
        {
            var newMail = EmailSenderHelper.CreateMessage(recipientEmail, subject, body, _emailSettings);

            var logStatus = LogStatus.Succeeded;

            try
            {
                using (var logStream = new MemoryStream())
                using (var protocolLogger = new ProtocolLogger(logStream)) using (var smtpInstance = new MailKit.Net.Smtp.SmtpClient(protocolLogger))
                {
                    await smtpInstance.ConnectAsync(_emailSettings.SmtpHost, _emailSettings.SecuredPort);

                    await smtpInstance.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);

                    string serverResponse = await smtpInstance.SendAsync(newMail);

                    await smtpInstance.DisconnectAsync(true);
                }
            }
            catch
            {
                logStatus = LogStatus.Failed;
            }
            return logStatus;
        }
    }
}
