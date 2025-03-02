using AuctionAPI.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace AuctionAPI.Infrastructure.ExceptionHandlers;

public class NotFoundExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is NotFoundException ex)
        {
            httpContext.Response.StatusCode = 404;

            await httpContext.Response.WriteAsJsonAsync(new { message = ex.Message }, cancellationToken);

            return true;
        }

        return false;
    }
}