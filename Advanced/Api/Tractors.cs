using BigMinimal.Advanced.Autoregistration;
using BigMinimal.Advanced.Contracts;
using BigMinimal.Advanced.Handlers.Tractors;

namespace BigMinimal.Advanced.Api;

/// <summary>
/// Vylepšená pipeline s MediatR (safe operace)
/// </summary>
public class Tractors : IApiRoute
{
    public void Register(RouteGroupBuilder group)
    {
        group.MapGet("tractors", async (IMediator mediator, [AsParameters]TractorFilter filter, CancellationToken ctn) =>
        {
            var request = new GetTractorRequest(filter);
            var result = await mediator.Send(request, ctn);

            return Results.Ok(result);
            
        }).WithName("GetTractors");
    }
}