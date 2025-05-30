using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BigMinimal.Advanced.ExceptionHandlers;

public class GeneralExceptionHandler(IHostEnvironment env) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ProblemDetails problem = new()
        {
            Type = "https://www.restapi.cz/probs/problem-details",
            Title = "Internal Server Error",
            Status = StatusCodes.Status500InternalServerError,
            Detail = env.IsDevelopment() ? exception.Message : null
        };

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);


        return true;
    }
}