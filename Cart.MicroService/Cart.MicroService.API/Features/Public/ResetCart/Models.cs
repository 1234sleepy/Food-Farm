using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.API.Features.Public.ResetCart;

public class Request
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

public class Response
{
    public CartModel Cart { get; set; }
}

