using Cart.MicroService.API.EndPoints.Public.GetCart;
using Cart.MicroService.Domain.UseCases.GetCartWolverine;
using Cart.MicroService.Domain.UseCases.RemoveProductFromCartWolverine;
using FastEndpoints;
using Wolverine;

namespace Cart.MicroService.API.EndPoints.Public.RemoveProductFromCart;

public class RemoveProductFromCartEndpoint(IMessageBus bus) : Endpoint<RemoveProductFromCartRequest>
{
    private readonly IMessageBus _bus = bus;

    public override void Configure()
    {
        Post("api/cart/remove-product-from-cart");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RemoveProductFromCartRequest r, CancellationToken c)
    {
        await _bus.InvokeAsync(new RemoveProductFromCartCommand(r.UserId, r.ProductId), c);
        await Send.OkAsync(c);
    }
}
