namespace Product.MicroService.Domain.Entities;

public class LabelEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<ProductLabelEntity>? ProductLabels { get; set; }
    public string? Color { get; set; }
}
