using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Command.RemoveLabelFromProduct
{
    public class RemoveLabelFromProductCommandHandler(IRemoveLabelFromProductStorage storage) : IRequestHandler<RemoveLabelFromProductCommand>
    {
        public async Task Handle(RemoveLabelFromProductCommand request, CancellationToken cancellationToken)
        {
            await storage.RemoveLabelFromProduct(
                request.productId,
                request.labelId, cancellationToken);
        }
    }
}
