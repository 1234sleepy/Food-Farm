using MediatR;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;

public class AddLabelToProductCommandHandler(IAddLabelToProductStorage storage) : IRequestHandler<AddLabelToProductCommand>
{
    public async Task Handle(AddLabelToProductCommand request, CancellationToken cancellationToken)
    {
        await storage.AddLabelToProduct(
            Guid.Parse(request.productId),
            Guid.Parse(request.labelId),
            cancellationToken);
    }
}
