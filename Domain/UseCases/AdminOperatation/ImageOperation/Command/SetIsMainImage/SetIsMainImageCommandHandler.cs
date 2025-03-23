using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.SetIsMainImage
{
    class SetIsMainImageCommandHandler(ISetIsMainImageStorage setIsMainImageStorage) : IRequestHandler<SetIsMainImageCommand, ImageModel>
    {
        private readonly ISetIsMainImageStorage _setIsMainImageStorage = setIsMainImageStorage;
        public async Task<ImageModel> Handle(SetIsMainImageCommand request, CancellationToken cancellationToken)
        {
            return await _setIsMainImageStorage.SetIsMainImage(request.imageId, cancellationToken);
        }
    }

}
