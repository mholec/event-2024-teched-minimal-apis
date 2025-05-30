using System.Text.Json.Serialization;
using BigMinimal.Basic.Contracts;

[JsonSerializable(typeof(Product))]
[JsonSerializable(typeof(ProductCreate))]
[JsonSerializable(typeof(Book))]
[JsonSerializable(typeof(Phone))]
[JsonSerializable(typeof(List<Product>))]
internal partial class JsonResolver : JsonSerializerContext
{
}