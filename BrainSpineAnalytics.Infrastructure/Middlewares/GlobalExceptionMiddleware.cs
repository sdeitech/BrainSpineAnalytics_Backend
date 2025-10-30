using BrainSpineAnalytics.Application.Interfaces.Repositories.ErrorHandling;
using BrainSpineAnalytics.Common.Constants;
using BrainSpineAnalytics.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;

namespace BrainSpineAnalytics.Infrastructure.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "Unhandled exception occurred at path {Path}", context.Request.Path);
            using var scope = _scopeFactory.CreateScope();
            var logRepo = scope.ServiceProvider.GetRequiredService<ILogRepo>();
            var error = new ErrorLog
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                InnerException = exception.InnerException?.Message,
                Source = exception.Source,
                Path = context.Request.Path
            };

            try
            {
                await logRepo.LogErrorAsync(error);
            }
            catch (Exception dbEx)
            {
                _logger.LogWarning(dbEx, "Failed to save error log to DB");
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var responseObj = new
            {
                StatusCode = context.Response.StatusCode,
                Message = CommonConstants.Messages.UnexpectedError,
                Detail = exception.Message
            };
            var json = System.Text.Json.JsonSerializer.Serialize(responseObj);
            await context.Response.WriteAsync(json, Encoding.UTF8);
        }
    }
}
