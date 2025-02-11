namespace Storage.Entities;

public class Order
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItem>? ItemsId { get; set; }
}
