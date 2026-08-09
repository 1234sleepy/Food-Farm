namespace Cart.MicroService.Domain.UseCases.Base;

public class CartModel
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
