namespace Storage.Entities;

public class Order
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public required string Phone { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public List<OrderItem>? Items { get; set; }
}
