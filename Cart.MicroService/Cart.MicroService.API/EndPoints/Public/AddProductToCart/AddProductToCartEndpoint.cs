using Cart.MicroService.Domain.UseCases.AddProductToCartWolverine;
using FastEndpoints;
using Wolverine;

namespace Cart.MicroService.API.EndPoints.Public.AddProductToCart;

public class AddProductToCartEndpoint(IMessageBus bus) : Endpoint<AddProductToCartRequest>
{
    private readonly IMessageBus _bus = bus;

    public override void Configure()
    {
        Post("api/cart/add-product-to-cart");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddProductToCartRequest r, CancellationToken c)
    {
        await _bus.InvokeAsync(new AddProductToCartCommand(r.UserId, r.ProductId, r.Quantity), c);
        await Send.OkAsync(c);
    }
}