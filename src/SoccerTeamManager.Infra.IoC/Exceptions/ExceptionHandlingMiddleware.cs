using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SoccerTeamManager.Infra.IoC.Exceptions
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new
            {
                status = statusCode,
                errors = GetErrors(exception)
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                ValidationException => StatusCodes.Status412PreconditionFailed,
                _ => StatusCodes.Status500InternalServerError
            };

        private static IReadOnlyDictionary<string, string[]>? GetErrors(Exception exception)
        {
            IReadOnlyDictionary<string, string[]>? errors = null;
            if (exception is ValidationException validationException)
            {
                errors = validationException.ErrorsDictionary;
            }
            return errors;
        }
    }
}