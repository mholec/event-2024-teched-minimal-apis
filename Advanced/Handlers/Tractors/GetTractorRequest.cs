using BigMinimal.Advanced.Contracts;

namespace BigMinimal.Advanced.Handlers.Tractors;

public class GetTractorRequest(TractorFilter filter) : IRequest<CollectionResult<Tractor>>
{
    public TractorFilter Filter { get; } = filter;
}