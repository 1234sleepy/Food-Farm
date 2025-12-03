
using Cart.MicroService.Domain.UseCases.Base;
using MediatR;

namespace Cart.MicroService.Domain.UseCases.CreateCart;

public class UpdateCartCommandHandler(IUpdateCartStorage storage) : IRequestHandler<UpdateCartCommand>
{
    private readonly IUpdateCartStorage _storage = storage;

    public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        await _storage.UpdateCart(request.UserId, request.ProductId, request.Quantity, cancellationToken);
    }
}
