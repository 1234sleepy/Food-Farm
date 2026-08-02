using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.CreateCart;
using Cart.MicroService.Domain.UseCases.ResetCart;
using FastEndpoints;
using Wolverine;
using static FastEndpoints.Ep;

namespace Cart.MicroService.API.EndPoints.Public.ResetCart;

public class ResetCartEndpoint(IMessageBus bus) : Endpoint<ResetCartRequest>
{
    private readonly IMessageBus _bus = bus;

    public override void Configure()
    {
        Post("api/cart/update");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ResetCartRequest r, CancellationToken c)
    {
        await _bus.InvokeAsync(r, c);
        await Send.OkAsync(c);
    }
}

