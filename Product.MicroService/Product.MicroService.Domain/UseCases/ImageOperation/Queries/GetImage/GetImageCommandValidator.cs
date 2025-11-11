using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetImage
{
    public class GetImageCommandValidator : AbstractValidator<GetImageCommand>
    {
        public GetImageCommandValidator(IGetImageStorage getImageStorage)
        {
            RuleFor(x => x.imageId)
                .MustAsync(getImageStorage.IsImageExists)
                .WithMessage("Image with this id does not exist");
        }
    }
}
