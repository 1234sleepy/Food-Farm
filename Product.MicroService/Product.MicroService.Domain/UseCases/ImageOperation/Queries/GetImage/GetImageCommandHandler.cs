using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetImage
{
    public class GetImageCommandHandler(IGetImageStorage getImageStorage) : IRequestHandler<GetImageCommand, ImageModel>
    {
        public async Task<ImageModel> Handle(GetImageCommand request, CancellationToken cancellationToken)
        {
            return await getImageStorage.GetImage(request.imageId, request.cancellationToken);
        }
    }
}
