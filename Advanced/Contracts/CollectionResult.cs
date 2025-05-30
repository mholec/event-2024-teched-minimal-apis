namespace BigMinimal.Advanced.Contracts;

public class CollectionResult<T>
{
    public List<T> Data { get; }

    public CollectionResult(List<T> data)
    {
        Data = data;
    }
}