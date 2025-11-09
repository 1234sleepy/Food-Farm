namespace Product.MicroService.Storage.Entities;

public class ProductLabel
{
    public Guid ProductId { get; set; }
    public ProductE? Product { get; set; }
    public Guid LabelId { get; set; }
    public Label? Label { get; set; }
}
