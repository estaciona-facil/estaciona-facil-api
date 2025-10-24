using Estacionamento.Api.Dto;
using System.Net;
using System.Text.Json;

namespace Estacionamento.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {

        private const string _contentType = "application/json";
        private readonly RequestDelegate _request;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _request = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _request(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = _contentType;

            _logger.LogError(exception, exception.Message);

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(new RetornoRequisicaoComErro(exception.Message))
            );
        }
    }

    internal static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
