

namespace Product.MicroService.Domain.Entities;

public class ProductLabelEntity
{
    public Guid ProductId { get; set; }
    public ProductEntity? Product { get; set; }
    public Guid LabelId { get; set; }
    public LabelEntity? Label { get; set; }
}
