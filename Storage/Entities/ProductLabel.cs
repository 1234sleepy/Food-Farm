namespace Storage.Entities;

public class ProductLabel
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public Guid LabelId { get; set; }
    public Label? Label { get; set; }
}
