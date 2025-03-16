using System.Reflection.Emit;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Base;

public class ImageModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public required string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public ProductModel? Product { get; set; }
    public bool IsMain { get; set; } = false;
    public required string ImageUrl { get; set; }
}
