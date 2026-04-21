using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Perfume.Exceptions;
using System;

namespace Perfume.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpcontext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var (StatusCode, Title) = exception switch
            {
                NotFoundException ex => (StatusCodes.Status404NotFound, ex.Title),
                _                    => (StatusCodes.Status500InternalServerError, "Sunucu hatası")
            };

            var problemDetails = new ProblemDetails
            {
                Status = StatusCode,
                Title = Title,
                Detail = exception.Message,
                Instance = httpcontext.Request.Path
            };

            httpcontext.Response.StatusCode = StatusCode;

            await httpcontext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }
}
