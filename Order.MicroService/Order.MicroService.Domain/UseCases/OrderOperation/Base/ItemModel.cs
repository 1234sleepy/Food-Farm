namespace Order.MicroService.Domain.UseCases.OrderOperation.Base;

public class ItemModel
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
