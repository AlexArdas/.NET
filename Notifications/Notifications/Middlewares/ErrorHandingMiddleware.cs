using FluentValidation;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace Notifications.WebAPI.Middlewares
{
    /// <summary>
    ///  Класс для обработки ошибок и предоставления подробных ответов об ошибках.
    /// </summary>
    public class ErrorHandingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Инициализирует новый экземпляр класса ErrorHandlingMiddleware.
        /// </summary>
        /// <param name="next">Обработке запросов.</param>
        public ErrorHandingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Обрабатывает исключения HTTP-запросов и предоставляет подробные ответы об ошибках.
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionVerboseAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionVerboseAsync(context, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Обрабатывает исключение и предоставляет подробный ответ об ошибке.
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса и ответа.</param>
        /// <param name="code">HTTP-код состояния для ответа.</param>
        /// <param name="message">Сообщение об ошибке.</param>
        /// <returns>Задача, представляющая асинхронное выполнение операции.</returns>
        private static Task HandleExceptionVerboseAsync(HttpContext context, HttpStatusCode code, string message)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)code;

            var errorResponse = new
            {
                ErrorMessage = message,
                StatusCode = code
            };

            var jsonResponse = JsonConvert.SerializeObject(errorResponse);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
