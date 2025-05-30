using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BigMinimal.Basic.ExceptionHandlers;

public class GeneralExHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Title = "Internal Server Error",
        }, cancellationToken: cancellationToken);

        return true;
    }
}