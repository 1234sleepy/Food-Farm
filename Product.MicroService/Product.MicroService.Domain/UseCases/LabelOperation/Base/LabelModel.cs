namespace Product.MicroService.Domain.UseCases.LabelOperation.Base;

public class LabelModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<Guid>? ProductId { get; set; }
    public string? Color { get; set; }
}
