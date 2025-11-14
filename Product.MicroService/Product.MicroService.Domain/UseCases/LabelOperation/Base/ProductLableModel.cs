using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Base;

public class ProductLabelModel
{
    public Guid ProductId { get; set; }
    public ProductModel? Product { get; set; }
    public Guid LabelId { get; set; }
    public LabelModel? Label { get; set; }
}
