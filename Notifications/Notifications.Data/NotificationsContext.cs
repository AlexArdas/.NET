using Microsoft.EntityFrameworkCore;
using Notifications.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Notifications.Data.Configurations
{
    /// <summary>
    /// Контекст базы данных приложения Notifications.
    /// </summary>
    public class NotificationsContext : DbContext
    {
        /// <summary>
        /// Набор данных для сущности EmailLog.
        /// </summary>
        public DbSet<EmailLog> EmailsLogs { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр контекста базы данных.
        /// </summary>
        /// <param name="options">Опции конфигурации контекста базы данных.</param>
        public NotificationsContext([NotNull] DbContextOptions<NotificationsContext> options) : base(options)
        {
        }

        /// <summary>
        /// Вызывается при создании модели для данного контекста.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmailLogConfiguration).Assembly);
        }

    }
}
