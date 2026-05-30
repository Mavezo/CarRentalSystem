using System.Net;
using CarRentalSystem.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CarRentalSystem.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
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
            // Default to 500
            var statusCode = (int)HttpStatusCode.InternalServerError;
            string message = "An unexpected error occurred.";
            string? errorCode = null;
            string? description = null;

            if (exception is AppException appEx)
            {
                statusCode = appEx.StatusCode;
                message = appEx.Message;
                errorCode = appEx.ErrorCode;
                description = appEx.Description;
            }
            else if (_env.IsDevelopment())
            {
                // In dev, include exception details
                message = exception.Message + "\n" + exception.StackTrace;
                description = exception.ToString();
            }

            _logger.LogError(exception, "Unhandled exception occurred: {Message}", exception.Message);

            // If request expects JSON (API) return JSON
            var acceptHeader = context.Request.Headers["Accept"].ToString();
            var isApi = context.Request.Path.StartsWithSegments("/api") || acceptHeader.Contains("application/json");

            context.Response.StatusCode = statusCode;

            if (isApi)
            {
                context.Response.ContentType = "application/json";
                var payload = new { success = false, message, errorCode, description };
                await context.Response.WriteAsJsonAsync(payload);
                return;
            }

            // For non-API requests, redirect to Error page with query params (message and optional description)
            var query = $"message={WebUtility.UrlEncode(message)}";
            if (!string.IsNullOrEmpty(description))
            {
                query += $"&description={WebUtility.UrlEncode(description)}";
            }

            var redirectUrl = $"/Home/Error?{query}";
            context.Response.Redirect(redirectUrl);
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
