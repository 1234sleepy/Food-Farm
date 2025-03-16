namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Base;

public class LabelModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public required string Name { get; set; }
    public ProductModel? Product { get; set; }
    public string? Color { get; set; }
}
