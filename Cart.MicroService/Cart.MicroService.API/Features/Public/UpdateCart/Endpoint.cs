using Cart.MicroService.Domain.UseCases.ResetCart;
using FastEndpoints;

namespace Cart.MicroService.API.Features.Public.UpdateCart;

public class Endpoint(IResetCartStorage storage) : Endpoint<Request>
{
    private readonly IResetCartStorage _storage = storage;

    public override void Configure()
    {
        Post("api/cart/reset");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        await Send.OkAsync( _storage.ResetCartCommand(r.UserId, c));
    }
}