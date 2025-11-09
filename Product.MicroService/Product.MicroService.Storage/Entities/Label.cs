namespace Product.MicroService.Storage.Entities;

public class Label
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<ProductLabel>? ProductLabels { get; set; }
    public string? Color { get; set; }
}
