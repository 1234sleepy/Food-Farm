using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.API.EndPoints.Public.AddProductToCart;
public class AddProductToCartRequest
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

public class AddProductToCartRwesponse
{
    public required CartModel Cart { get; set; }
}