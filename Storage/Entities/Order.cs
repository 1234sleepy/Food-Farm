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
}
