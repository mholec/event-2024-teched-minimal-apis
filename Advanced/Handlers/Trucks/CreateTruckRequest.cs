using BigMinimal.Advanced.Contracts;

namespace BigMinimal.Advanced.Handlers.Trucks;

public class CreateTruckRequest (TruckCreate truck) : IRequest<Guid>
{
    public TruckCreate Truck { get; } = truck ?? new TruckCreate();
}