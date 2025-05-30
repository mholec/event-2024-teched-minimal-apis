using System.Text.Json;
using BigMinimal.Basic.Contracts;
using BigMinimal.Basic.ExceptionHandlers;
using BigMinimal.Basic.Results;
using BigMinimal.Basic.Services;
using Microsoft.AspNetCore.Mvc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(x => x.AddPolicy("Default", p => p.AllowAnyOrigin()));
builder.Services.AddKeyedTransient<IProductService, ProductService>("product");
builder.Services.AddKeyedTransient<IProductService, DummyProductService>("dummy");
builder.Services.AddProblemDetails(x =>
{
    x.CustomizeProblemDetails = (ctx) =>
    {
        var endpoint = ctx.HttpContext.GetEndpoint();
        if (ctx.HttpContext.Response.StatusCode == 404)
        {
            if(endpoint is null)
            {
                ctx.ProblemDetails.Title = "Path Not Found";
            }
            else
            {
                ctx.ProblemDetails.Title = "Object by ID Not Found";
            }

        }

    };
})
.AddExceptionHandler<ArgumentExHandler>()
.AddExceptionHandler<GeneralExHandler>();

builder.Services.ConfigureHttpJsonOptions(x =>
{
    x.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

WebApplication app = builder.Build();
app.UseExceptionHandler();
app.UseStatusCodePages();

app.UseCors();

var group = app.MapGroup("api").RequireCors("Default");

group.MapGet("products/{id:int}", (int id, [FromKeyedServices("product")]IProductService productService) =>
{
    var product = productService.GetProduct(id);

    switch (id)
    {
        case 888:
            throw new ApplicationException("888 not allowed");
        case 999:
            throw new ArgumentException("999 not allowed");
    }

    if (product == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(product);
})
.WithName("GetProductById");

group.MapGet("/products", ([FromHeader] string accept, [AsParameters] ProductsFilter filter, [FromKeyedServices("product")]IProductService productService) =>
{
    var data = productService.GetProducts(filter.Take, filter.Skip);

    if (accept == "text/csv")
    {
        return Results.Extensions.Csv(data.Select(x => x as object).ToList());
    }

    return Results.Ok(data);
});

group.MapPost("products", (ProductCreate model, [FromKeyedServices("product")]IProductService productService) =>
{
    var id = productService.CreateProduct(model);
    var product = productService.GetProduct(id);

    return Results.CreatedAtRoute("GetProductById", new {id}, product);
});

app.Run();