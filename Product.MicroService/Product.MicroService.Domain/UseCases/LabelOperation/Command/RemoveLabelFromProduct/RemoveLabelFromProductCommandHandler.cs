using MediatR;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Command.RemoveLabelFromProduct;

public class RemoveLabelFromProductCommandHandler(IRemoveLabelFromProductStorage storage) : IRequestHandler<RemoveLabelFromProductCommand>
{
    public async Task Handle(RemoveLabelFromProductCommand request, CancellationToken cancellationToken)
    {
        await storage.RemoveLabelFromProduct(
            request.productId,
            request.labelId, cancellationToken);
    }
}
