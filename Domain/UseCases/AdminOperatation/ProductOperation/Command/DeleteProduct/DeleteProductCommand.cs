using MediatR;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public DeleteProductCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get;}
}
