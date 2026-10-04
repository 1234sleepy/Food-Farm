namespace Product.MicroService.Domain.Entities;

public class ProductMetricsEntity
{
    public int QuantitySold { get; set; }
    public int QuantityLimit { get; set; }
    public int TotalCommentsQuantity { get; set; }
    public int TotalRating { get; set; }
}
