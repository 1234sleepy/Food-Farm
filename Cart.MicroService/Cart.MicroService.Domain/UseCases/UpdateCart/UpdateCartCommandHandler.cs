
using Cart.MicroService.Domain.UseCases.Base;
using MediatR;

namespace Cart.MicroService.Domain.UseCases.CreateCart;

public class UpdateCartCommandHandler(IUpdateCartStorage storage) : IRequestHandler<UpdateCartCommand, CartModel>
{
    private readonly IUpdateCartStorage _storage = storage;

    public async Task<CartModel> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
       return await _storage.UpdateCart(request.UserId, request.ProductId, request.Quantity, cancellationToken);
    }

}
