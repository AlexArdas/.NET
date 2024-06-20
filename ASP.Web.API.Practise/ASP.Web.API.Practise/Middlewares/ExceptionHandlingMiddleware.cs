using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ASP.Web.API.Practise.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate) 
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (NotFoundException ex) 
            {
                await HandleException(context, ex, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        private Task HandleException<T>(HttpContext context, T ex, HttpStatusCode statusCode) where T : Exception
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(new 
            { 
                errorMessage = ex.Message, 
                sourse = ex.Source 
            }));
        }
    }
}
