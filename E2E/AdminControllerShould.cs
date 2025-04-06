using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using FluentAssertions;
using System.Net.Http.Json;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace E2E;

public class AdminControllerShould(FoodFarmApplicationFactory factory, ITestOutputHelper testOutputHelper) : IClassFixture<FoodFarmApplicationFactory>
{
    private readonly FoodFarmApplicationFactory _factory = factory;
    private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

    [Fact]
    public async Task AddProduct()
    {
        using var _client = _factory.CreateClient();
        var swagger = await _client.GetStringAsync("swagger/v1/swagger.json");
        _testOutputHelper.WriteLine(swagger);
        using var productsResponse = await _client.GetAsync("api/product");
        _testOutputHelper.WriteLine($"Status code: {productsResponse.StatusCode}");
        productsResponse.IsSuccessStatusCode.Should().BeTrue();
        var product = new
        {
            Name = "Test Product",
            Price = 10.0,
            Description = "This is a test product"
        };
        var createProductRequest = new HttpRequestMessage(HttpMethod.Post, "api/admin/product")
        {
            Content = JsonContent.Create(product)
        };
        using var response = await _client.SendAsync(createProductRequest);

        response.IsSuccessStatusCode.Should().BeTrue();

        var createdProduct = await response.Content.ReadFromJsonAsync<ProductModel>();
        createdProduct!.Name.Should().Be(product.Name);


        //var getResponse = await _client.GetAsync("/api/product");
        //getResponse.EnsureSuccessStatusCode();

        //var products = await getResponse.Content.ReadFromJsonAsync<List<dynamic>>();

        //Assert.NotEmpty(products);
        //Assert.Contains(products!, p => p.Name == product.Name && p.Price == product.Price);
    }
}