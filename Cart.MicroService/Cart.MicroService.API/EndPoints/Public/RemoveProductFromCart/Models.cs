using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.API.EndPoints.Public.RemoveProductFromCart;

public class RemoveProductFromCartRequest
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}