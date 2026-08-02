using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.API.EndPoints.Public.ResetCart;


public class ResetCartRequest
{
    public Guid UserId { get; set; }
}
