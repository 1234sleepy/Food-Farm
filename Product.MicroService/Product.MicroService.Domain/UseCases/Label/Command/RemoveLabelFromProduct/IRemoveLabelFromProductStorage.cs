using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Command.RemoveLabelFromProduct
{
    public interface IRemoveLabelFromProductStorage
    {
        Task RemoveLabelFromProduct(Guid productId, Guid labelId, CancellationToken cancellationToken);
    }
}
