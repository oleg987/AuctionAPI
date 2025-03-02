using AuctionAPI.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace AuctionAPI.Infrastructure.ExceptionHandlers;

public class CustomValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is CustomValidationException ex)
        {
            httpContext.Response.StatusCode = 400;

            await httpContext.Response.WriteAsJsonAsync(ex.Details, cancellationToken);

            return true;
        }

        return false;
    }
}