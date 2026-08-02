using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.API.EndPoints.Public.UpdateCart;

public class UpdateCartRequest
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

public class UpdateCartResponse
{
    public CartModel Cart { get; set; }
}
