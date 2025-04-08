using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.SetIsMainImage
{
    public interface ISetIsMainImageStorage
    {
        Task<ImageModel> SetIsMainImage(Guid imageId, CancellationToken cancellationToken);

        Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken);
    }
}
