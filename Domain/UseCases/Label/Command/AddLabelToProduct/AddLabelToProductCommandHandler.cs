using Domain.UseCases.Comment.Command.AddComment;
using Domain.UseCases.Label.Base;
using MediatR;
using Storage.Entities;

namespace Domain.UseCases.Label.Command.AddLabelToProduct;

public class AddLabelToProductCommandHandler(IAddLabelToProductStorage storage) : IRequestHandler<AddLabelToProductCommand>
{
    public async Task Handle(AddLabelToProductCommand request, CancellationToken cancellationToken)
    {
        await storage.AddLabelToProductAsync(
            Guid.Parse(request.productId),
            Guid.Parse(request.labelId),
            cancellationToken);
    }
}
