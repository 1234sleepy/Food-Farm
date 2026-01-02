namespace Product.MicroService.Storage.Entities;

public class ProductE
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int QuantitySold { get; set; }
    public int QuantityLimit { get; set; }
    public List<Image>? Images { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int TotalCommentsQuantity { get; set; }
    public int TotalRating { get; set; }
    public List<ProductLabel>? ProductLabel { get; set; }
    public bool IsVisible { get; set; } = true;
    public string? Characteristics { get; set; }
}
