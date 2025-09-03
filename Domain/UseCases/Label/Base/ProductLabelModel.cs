using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.Label.Base;

public class ProductLabelModel
{
    public Guid ProductId { get; set; }
    public ProductModel? Product { get; set; }
    public Guid LabelId { get; set; }
    public LabelModel? Label { get; set; }
}
