namespace Storage.Entities;

public class Image
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public required string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Product? Product { get; set; }
    public bool IsMain { get; set; } = false;
}
