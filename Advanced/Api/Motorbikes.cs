using BigMinimal.Advanced.Autoregistration;

namespace BigMinimal.Advanced.Api;

/// <summary>
/// SubGroups a vytváření endpoint filtrů
/// </summary>
public class Motorbikes : IApiRoute
{
    public void Register(RouteGroupBuilder group)
    {
        var sub = group.MapGroup("motorbikes");

        sub.AddEndpointFilter(async (context, next) =>
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<Motorbikes>>();

            logger.LogInformation("Hello before execution");
            var result = await next(context);
            logger.LogInformation("Goodbye after execution");

            return result;
        });

        sub.MapGet("", () => { });
        sub.MapGet("{id:int}", (int id) =>
        {
            if (id == 999)
            {
                throw new ApplicationException("Example error for handler demo");
            }
        }).AddEndpointFilter<LoggingEndpointFilter>();

        sub.MapDelete("{id:int}", (int id) => { });
    }
}

public class LoggingEndpointFilter(ILogger<LoggingEndpointFilter> logger) : IEndpointFilter
{
    public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        logger.LogInformation("Hello before execution external");

        var result = await next(context);

        logger.LogInformation("Goodbye after execution external");

        return result;
    }
}