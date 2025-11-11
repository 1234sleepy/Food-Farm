using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Command.AddLabelToProduct
{
    public interface IAddLabelToProductStorage
    {
        Task AddLabelToProductAsync(Guid productId, Guid labelId, CancellationToken cancellationToken);
    }
}
