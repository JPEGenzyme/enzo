using AdventureWorksAPI.Controllers;
using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AdventureWorksLt2022Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AdventureWorks API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdventureWorks API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AdventureWorksLt2022Context>();
    var productsController = new ProductsController(context);
    
    // Fetch and log products
    var products = await productsController.GetProducts();
    
    if (products.Value != null)
    {
        Console.WriteLine("Products table contents:");
        foreach (var product in products.Value)
        {
            Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}");
        }
    }
    else
    {
        Console.WriteLine("No products found.");
    }
}


app.Run();
