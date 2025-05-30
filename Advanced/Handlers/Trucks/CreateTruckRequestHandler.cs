namespace BigMinimal.Advanced.Handlers.Trucks;

public class CreateTruckRequestHandler : RequestHandler<CreateTruckRequest, Guid>
{
    protected override Guid Handle(CreateTruckRequest request)
    {
        return Guid.NewGuid();
    }
}