using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.CreateCart;
using FastEndpoints;

namespace Cart.MicroService.API.Features.Public.ResetCart;

public class Endpoint(IUpdateCartStorage storage) : Endpoint<Request, Response>
{
    private readonly IUpdateCartStorage _storage = storage;

    public override void Configure()
    {
        Post("api/cart/update");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        CartModel cart = await _storage.UpdateCart(r.UserId, r.ProductId, r.Quantity, c);

        await Send.ResultAsync(TypedResults.Ok<Response>(new()
        {
            Cart = cart
        }));
    }
}