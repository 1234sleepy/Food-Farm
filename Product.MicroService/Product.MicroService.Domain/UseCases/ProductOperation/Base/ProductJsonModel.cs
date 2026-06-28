namespace Product.MicroService.Domain.UseCases.ProductOperation.Base;

public class ProductJsonModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public int QuantityLimit { get; set; }
    public string Characteristics { get; set; }
    public List<LabelJsonModel> Labels { get; set; }
}


public class LabelJsonModel
{
    public string Name { get; set; }
    public string Color { get; set; }
}