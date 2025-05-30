using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BigMinimal.Advanced.ExceptionHandlers;

public class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException e)
        {
            return false;
        }

        ProblemDetails problem = new()
        {
            Type = "https://www.restapi.cz/probs/validation-problem-details",
            Title = "Validation Failed",
            Status = StatusCodes.Status400BadRequest,
        };

        problem.Extensions.Add("errors", e.Errors.Select(x=> new
        {
            x.PropertyName, x.ErrorMessage
        }));

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}