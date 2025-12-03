namespace Cart.MicroService.Storage.Entities;

public class CartEntity
{
    public Guid userId { get; set; }
    public Guid productId { get; set; }
    public int quantity { get; set; }
}
