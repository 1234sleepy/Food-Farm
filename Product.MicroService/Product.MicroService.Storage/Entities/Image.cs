namespace Product.MicroService.Storage.Entities;

public class Image
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public required string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public ProductE? Product { get; set; }
    public bool IsMain { get; set; } = false;
}
