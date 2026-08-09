using Cart.MicroService.API.EndPoints.Public.ResetCart;
using Cart.MicroService.Domain.UseCases.GetCartWolverine;
using FastEndpoints;
using Wolverine;

namespace Cart.MicroService.API.EndPoints.Public.GetCart;

public class GetCartEndpoint(IMessageBus bus) : Endpoint<GetCartRequest>
{
    private readonly IMessageBus _bus = bus;

    public override void Configure()
    {
        Post("api/cart/get");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetCartRequest r, CancellationToken c)
    {
        await _bus.InvokeAsync(new GetCartCommand(r.UserId), c);
        await Send.OkAsync(c);
    }
}
