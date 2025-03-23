using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Queries.GetImage
{
    public class GetImageCommandHandler(IGetImageStorage getImageStorage) : IRequestHandler<GetImageCommand, ImageModel>
    {
        public async Task<ImageModel> Handle(GetImageCommand request, CancellationToken cancellationToken)
        {
            return await getImageStorage.GetImage(request.imageId, request.cancellationToken);
        }
    }
}
