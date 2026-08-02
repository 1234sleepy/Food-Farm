using Cart.MicroService.Domain.UseCases.ResetCart;
using FastEndpoints;
using Wolverine;

namespace Cart.MicroService.API.EndPoints.Public.UpdateCart;

public class UpdateCartEndpoint(IMessageBus bus) : Endpoint<UpdateCartRequest, UpdateCartResponse>
{
    private readonly IMessageBus _bus = bus;

    public override void Configure()
    {
        Post("api/cart/reset");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateCartRequest r, CancellationToken c)
    {
        await _bus.InvokeAsync(r, c);
        await Send.OkAsync(c);
    }
}