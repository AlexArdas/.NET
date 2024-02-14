using System.ComponentModel;

namespace Notifications.Domain.Enums
{
    /// <summary>
    /// Статус лога электронного письма.
    /// </summary>
    public enum LogStatus
    {
        /// <summary>
        /// Успешное выполнение.
        /// </summary>
        [Description("Успешно")]
        Succeeded = 0,

        /// <summary>
        /// Ошибка при выполнении.
        /// </summary>
        [Description("Ошибка")]
        Failed = 1,
    }
}
