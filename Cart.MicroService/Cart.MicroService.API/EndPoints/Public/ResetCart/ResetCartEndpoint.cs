using Cart.MicroService.Domain.UseCases.ResetCartWolverine;
using FastEndpoints;
using Wolverine;

namespace Cart.MicroService.API.EndPoints.Public.ResetCart;

public class ResetCartEndpoint(IMessageBus bus) : Endpoint<ResetCartRequest>
{
    private readonly IMessageBus _bus = bus;

    public override void Configure()
    {
        Post("api/cart/reset");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ResetCartRequest r, CancellationToken c)
    {
        await _bus.InvokeAsync(new ResetCartCommand(r.UserId), c);
        await Send.OkAsync(c);
    }
}

