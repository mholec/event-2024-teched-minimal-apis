using BigMinimal.Advanced.Contracts;

namespace BigMinimal.Advanced.Handlers.Tractors;

public class GetTractorRequestHandler : RequestHandler<GetTractorRequest, CollectionResult<Tractor>>
{
    protected override CollectionResult<Tractor> Handle(GetTractorRequest request)
    {
        var data = new List<Tractor>()
        {
            new Tractor() {Title = "Test tractor 1"},
            new Tractor() {Title = "Test tractor 2"},
            new Tractor() {Title = "Test tractor 3"}
        }
            .Skip(request.Filter.Skip ?? 0).Take(request.Filter.Take ?? 10).ToList();

        return new CollectionResult<Tractor>(data);
    }
}