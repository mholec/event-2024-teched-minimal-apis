namespace BigMinimal.Advanced.Autoregistration;

public static class WebApplicationExtensions
{
    /// <summary>
    /// Provádí registraci z tříd, které implementují IApiRoute
    /// </summary>
    public static void RegisterApiRoutes(this WebApplication app)
    {
        var group = app.MapGroup("api");

        var type = typeof(IApiRoute);
        var types = type.Assembly.GetTypes().Where(p => p.IsClass && p.IsAssignableTo(type));

        foreach (var routeType in types)
        {
            var route = (IApiRoute)Activator.CreateInstance(routeType);
            route.Register(group);
        }

        group.ShortCircuit();
    }
}