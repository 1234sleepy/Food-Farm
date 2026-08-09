using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.Domain.UseCases.GetCartWolverine;

public interface IGetCartStorage
{
    Task<List<CartModel>> GetCart(Guid userId, CancellationToken cancellationToken);
}
