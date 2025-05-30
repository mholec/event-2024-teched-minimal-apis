using BigMinimal.Basic.Contracts;

namespace BigMinimal.Basic.Services;

public class ProductService : IProductService
{
    private const int MaxProducts = 100;

    public Product GetProduct(int id)
    {
        if (id > MaxProducts)
            return null;

        return Product.FakeDemoProduct(id); // TODO
    }

    public int CreateProduct(ProductCreate product)
    {
        return 1;
    }

    public List<Product> GetProducts(int take, int skip)
    {
        var products = GetDemoProducts(count:100);

        return products.Skip(skip).Take(take).ToList();
    }

    // vygeneruje produkty pro účely ukázek
    private static List<Product> GetDemoProducts(int count)
    {
        count = count > MaxProducts ? MaxProducts : count;

        List<Product> products = new();

        for (int i = 1; i <= count; i++)
        {
            products.Add(Product.FakeDemoProduct(i));
        }

        return products;
    }
}