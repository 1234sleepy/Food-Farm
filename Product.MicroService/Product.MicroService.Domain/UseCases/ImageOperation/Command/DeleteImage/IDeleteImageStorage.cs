using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.DeleteImage
{
    public interface IDeleteImageStorage
    {
        Task DeleteImage(Guid imageId, CancellationToken cancellationToken);

        Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken);
    }
}
