using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notifications.BL.MediatR.Commands;
using Notifications.BL.MediatR.Queries;
using Notifications.Domain.Models;
using Notifications.WebAPI.Models.Request;

namespace Notifications.Controllers
{
    /// <summary>
    /// Контроллер для управления электронными письмами.
    /// </summary>
    [ApiController]
    [Route("api/mails")]
    [Produces("application/json")]
    public class EmailController : ControllerBase
    {

        private readonly IMediator _mediator;

        /// <summary>
        /// Конструктор контроллера EmailController.
        /// </summary>
        /// <param name="mediator"></param>
        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary> 
        /// Отправить сообщение указанным получателям. 
        /// </summary> 
        /// <param name="sendEmailRequest">Модель отправки сообщения.</param> 
        /// <returns>Результат выполнения операции.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SendEmails([FromBody] SendEmailsRequest sendEmailRequest)
        {
            await _mediator.Send(new SendEmailsCommand
            {
                Subject = sendEmailRequest.Subject,
                Body = sendEmailRequest.Body,
                Recipients = sendEmailRequest.Recipients
            }, HttpContext?.RequestAborted ?? default);

            return Ok();
        }

        /// <summary>
        /// Получить список электронных писем.
        /// </summary>
        /// <returns>Список моделей электронных писем.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmailLogModel[]>> GetEmails()
        {
            var result = await _mediator.Send(new GetEmailsQuery());

            return Ok(result);
        }
    }
}
