namespace BigMinimal.Advanced.Extensions;

public class ProblemDetailsConfiguration
{
    public static Action<ProblemDetailsOptions> Configure()
    {
        return x=> x.CustomizeProblemDetails = (context) =>
        {
            if (context.HttpContext.Response.StatusCode == 404)
            {
                if (context.HttpContext.GetEndpoint() == null)
                {
                    context.ProblemDetails.Title = "Path not found";
                    context.ProblemDetails.Detail = "No endpoint found for the request path.";
                }
                else
                {
                    context.ProblemDetails.Title = "Resource not found";
                    context.ProblemDetails.Detail = "The specified resource was not found.";
                }
            }
        };
    }
}