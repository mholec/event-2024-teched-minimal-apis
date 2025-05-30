using BigMinimal.Advanced.Autoregistration;
using BigMinimal.Advanced.Contracts;
using BigMinimal.Advanced.Handlers.Trucks;
using Microsoft.AspNetCore.Mvc;

namespace BigMinimal.Advanced.Api;

/// <summary>
/// Validace s Fluent Validatin a MediatR
/// </summary>
public class Trucks : IApiRoute
{
    public void Register(RouteGroupBuilder group)
    {
        group.MapPost("trucks", async ([FromBody]TruckCreate model, IMediator mediator) =>
        {
            var request = new CreateTruckRequest(model);
            var result = await mediator.Send(request);

            return Results.Ok(result);
        });
    }
}