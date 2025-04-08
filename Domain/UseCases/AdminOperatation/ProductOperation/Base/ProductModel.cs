namespace Domain.UseCases.AdminOperatation.ProductOperation.Base;

public class ProductModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public required string Description { get; set; }
    public int QuantityLimit { get; set; }
    public bool IsVisible { get; set; } = true;
    public decimal? DiscountPrice { get; set; }
    public int? QuantitySold { get; set; }
    public List<ImageModel>? Images { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int? TotalCommentsQuantity { get; set; }
    public int? TotalRating { get; set; }
    public List<LabelModel>? Labels { get; set; }
}
