using Domain.UseCases.OrderItemOperation.Base;

namespace Domain.UseCases.AdminOperatation.AdminOrderOperation.Base;

public class OrderModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Phone { get; set; }
    public string? Email { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public List<OrderItemModel>? Items { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalDiscount { get; set; }
}
