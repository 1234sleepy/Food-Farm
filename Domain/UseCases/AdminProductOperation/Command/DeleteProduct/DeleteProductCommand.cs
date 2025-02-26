using MediatR;

namespace Domain.UseCases.AdminProductOperation.Command.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public required Guid Id { get; set; }
}
