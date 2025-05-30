namespace BigMinimal.Basic.Contracts;

public class ProductsFilter
{
    public int? Page { get; set; } = 1;
    public int? PageSize { get; set; } = 10;

    public int Take => PageSize ?? 10;
    public int Skip => ((Page ?? 1) - 1) * Take;
}