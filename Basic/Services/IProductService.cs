using BigMinimal.Basic.Contracts;

namespace BigMinimal.Basic.Services;

public interface IProductService
{
    Product GetProduct(int id);
    int CreateProduct(ProductCreate product);
    List<Product> GetProducts(int take, int skip);
}

public class DummyProductService : IProductService
{
    public Product GetProduct(int id)
    {
        return new();
    }

    public int CreateProduct(ProductCreate product)
    {
        return 0;
    }

    public List<Product> GetProducts(int take, int skip)
    {
        return new();
    }
}