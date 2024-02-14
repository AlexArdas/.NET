using MediatR;
using Notifications.Domain.Models;

namespace Notifications.BL.MediatR.Queries
{
    /// <summary>
    /// Запрос для получения логов электронных писем.
    /// </summary>
    public class GetEmailsQuery : IRequest<EmailLogModel[]>
    {
    }
}
