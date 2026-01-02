namespace Product.MicroService.Domain.UseCases.ProductOperation.Base;

public class ProductMetricsModel
{
    public int QuantitySold { get; set; }
    public int QuantityLimit { get; set; }
    public int TotalCommentsQuantity { get; set; }
    public int TotalRating { get; set; }
}
