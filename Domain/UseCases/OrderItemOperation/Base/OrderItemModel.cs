using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminProductOperation.Base;

namespace Domain.UseCases.OrderItemOperation.Base;

public class OrderItemModel
{
    public Guid OrderId { get; set; }
    public OrderModel? Order { get; set; }
    public Guid ProductId { get; set; }
    public ProductModel? Product { get; set; }
    public int Quantity { get; set; }
}
