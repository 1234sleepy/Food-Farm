using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.SetlsMainImage
{
    public interface ISetIsMainImageStorage
    {
        Task<ImageModel> SetIsMainImage(Guid imageId, CancellationToken cancellationToken);

        Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken);
    }
}
