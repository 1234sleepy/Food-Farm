namespace Product.MicroService.Domain.Entities;

public class ImageEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public required string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public ProductEntity? Product { get; set; }
    public bool IsMain { get; set; } = false;
}
