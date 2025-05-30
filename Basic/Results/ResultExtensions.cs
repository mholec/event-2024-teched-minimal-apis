namespace BigMinimal.Basic.Results;

public static class ResultExtensions
{
    public static IResult Csv(this IResultExtensions extensions, List<object> data)
    {
        return new CsvResult(data);
    }
}