using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.UpdateProduct;

public record class UpdateProductCommand(string name, decimal price,
        int quantityLimit, string description,
        bool isVisible, decimal discountPrice, CancellationToken cancellationToken) : IRequest<ProductModel>
{
    public Guid Id { get; set; }
}
