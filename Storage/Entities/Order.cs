namespace Storage.Entities;

public class Order
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Phone { get; set; }
    public string? Email { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public List<OrderItem>? Items { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalDiscount { get; set; }
    public Guid StatusId { get; set; } = Guid.Parse("e0add828-035e-4fed-a27f-d31ae22ad9c2");
    public OrderStatus? Status { get; set; }
}
