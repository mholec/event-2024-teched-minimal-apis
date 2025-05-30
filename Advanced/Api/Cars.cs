using BigMinimal.Advanced.Autoregistration;

namespace BigMinimal.Advanced.Api;

/// <summary>
/// Základní ukázka registrace nad group
/// </summary>
public class Cars : IApiRoute
{
    public void Register(RouteGroupBuilder group)
    {
        group.MapGet("cars", () =>
        {
        });
    }
}