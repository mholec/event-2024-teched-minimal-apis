using System.Text.Json.Serialization;

namespace BigMinimal.Basic.Contracts;

[JsonDerivedType(typeof(Product), "product")]
[JsonDerivedType(typeof(Book), "book")]
[JsonDerivedType(typeof(Phone), "phone")]
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ProductCode => $"P-{Id}";

    public static Product FakeDemoProduct(int id)
    {
        if (id == 1)
        {
            return new Book(){Id = 1, Title = "Book no 1" ,Isbn = "978-3-16-148410-0"};
        }

        if (id == 3)
        {
            return new Phone() {Id = 3, Title = "Phone number 3", OperatingSystem = "iOS"};
        }

        return new Product()
        {
            Id = id,
            Title = $"Product number {id}"
        };
    }
}

public class Book : Product
{
    public string Isbn { get; set; }
}

public class Phone : Product
{
    public string OperatingSystem { get; set; }
}