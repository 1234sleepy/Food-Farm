using Cart.MicroService.Domain.UseCases.Base;
using MediatR;

namespace Cart.MicroService.Domain.UseCases.CreateCart;

public record class UpdateCartCommand(Guid UserId, Guid ProductId, int Quantity) : IRequest<CartModel>
{
}
