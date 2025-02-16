namespace Storage.Entities;

public class Label
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public required string Name { get; set; }
    public Product? Product { get; set; }
    public string? Color { get; set; }
}
