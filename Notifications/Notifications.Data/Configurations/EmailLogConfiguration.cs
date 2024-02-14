using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;

namespace Notifications.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="EmailLog"/>.
    /// </summary>
    public class EmailLogConfiguration : IEntityTypeConfiguration<EmailLog>
    {
        /// <summary>
        /// Настраивает схему сущности <see cref="EmailLog"/>.
        /// </summary>
        /// <param name="builder">Построитель модели сущности.</param>
        public void Configure(EntityTypeBuilder<EmailLog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SenderEmail).IsRequired();

            builder.Property(x => x.RecipientEmail).IsRequired();

            builder.Property(x => x.Subject).IsRequired();

            builder.Property(x => x.Body).IsRequired();

            builder.Property(x => x.Status).IsRequired();
        }
    }
}
