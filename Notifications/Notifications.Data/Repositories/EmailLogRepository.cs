using Microsoft.EntityFrameworkCore;
using Notifications.Data.Configurations;
using Notifications.Domain.Entities;
using Notifications.Domain.Models;
using Notifications.Domain.Repositories;

namespace Notifications.Data.Repositories
{
    /// <summary>
    /// Репозиторий для работы с логами электронных писем.
    /// </summary>
    public class EmailLogRepository : IEmailLogRepository
    {
        private readonly NotificationsContext _dbContext;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория EmailLog.
        /// </summary>
        /// <param name="dbContext">Контекст базы данных.</param>
        public EmailLogRepository(NotificationsContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task AddEmailsLogsAsync(IEnumerable<EmailLog> emailsLogs, CancellationToken cancellationToken)
        {
            await _dbContext.AddRangeAsync(emailsLogs, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<EmailLogModel[]> GetEmailLogsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.EmailsLogs.Select(x => new EmailLogModel
            {
                Id = x.Id,
                SenderEmail = x.SenderEmail,
                Subject = x.Subject,
                Body = x.Body,
                RecipientEmail = x.RecipientEmail,
                Status = x.Status,
            }).ToArrayAsync(cancellationToken);
        }
    }
}
