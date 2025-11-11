using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Command.AddLabelToProduct
{
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
}
