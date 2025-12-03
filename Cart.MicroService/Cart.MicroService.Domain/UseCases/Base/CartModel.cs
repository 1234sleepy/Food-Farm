namespace Cart.MicroService.Domain.UseCases.Base;

public class CartModel
{
    public Guid userId { get; set; }
    public Guid productId { get; set; }
    public int quantity { get; set; }
}
