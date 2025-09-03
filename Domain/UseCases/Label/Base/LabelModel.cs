namespace Domain.UseCases.Label.Base;

public class LabelModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<ProductLabelModel>? ProductLabels { get; set; }
    public string? Color { get; set; }
}
