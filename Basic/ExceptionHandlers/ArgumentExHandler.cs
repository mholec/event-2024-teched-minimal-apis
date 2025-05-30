using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BigMinimal.Basic.ExceptionHandlers;

public class ArgumentExHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is ArgumentException)
        {
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
            {
                Title = "Argument Exception",
            }, cancellationToken: cancellationToken);

            return true;
        }

        return false;
    }
}