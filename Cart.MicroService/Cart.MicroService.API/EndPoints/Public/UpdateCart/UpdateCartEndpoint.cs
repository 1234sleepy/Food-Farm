using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.ResetCart;
using Cart.MicroService.Domain.UseCases.UpdateCartWolverine;
using FastEndpoints;
using Wolverine;

namespace Cart.MicroService.API.EndPoints.Public.UpdateCart;

public class UpdateCartEndpoint(IMessageBus bus) : Endpoint<UpdateCartRequest, UpdateCartResponse>
{
    private readonly IMessageBus _bus = bus;

    public override void Configure()
    {
        Post("api/cart/update");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateCartRequest r, CancellationToken c)
    {
        var cart = await _bus.InvokeAsync<UpdateCartResponse>(new UpdateCartCommand(r.UserId, r.ProductId, r.Quantity), c);
        await Send.OkAsync(cart, c);
    }
}