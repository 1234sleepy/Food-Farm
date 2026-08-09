using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.API.EndPoints.Public.GetCart;

public class GetCartRequest
{
    public Guid UserId { get; set; }
}

public class GetCartResponse
{
    public List<CartModel> Cart { get; set; } = [];
}