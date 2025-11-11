using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.SetlsMainImage
{
    public class SetlsMainImageCommandHandler(ISetIsMainImageStorage setIsMainImageStorage) : IRequestHandler<SetIsMainImageCommand, ImageModel>
    {
        private readonly ISetIsMainImageStorage _setIsMainImageStorage = setIsMainImageStorage;
        public async Task<ImageModel> Handle(SetIsMainImageCommand request, CancellationToken cancellationToken)
        {
            return await _setIsMainImageStorage.SetIsMainImage(request.imageId, cancellationToken);
        }
    }
}
