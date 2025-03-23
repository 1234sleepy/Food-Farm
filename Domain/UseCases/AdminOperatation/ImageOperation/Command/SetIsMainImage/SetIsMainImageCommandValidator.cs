using Domain.UseCases.AdminOperatation.ImageOperation.Queries.GetImage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.SetIsMainImage
{
    public class SetIsMainImageCommandValidator : AbstractValidator<SetIsMainImageCommand>
    {
        public SetIsMainImageCommandValidator(ISetIsMainImageStorage setIsMainImageStorage)
        {
            RuleFor(x => x.imageId).NotEmpty().WithMessage("Image Id cannot be empty");

            RuleFor(x => x.imageId)
                .MustAsync(setIsMainImageStorage.IsImageExists)
                .WithMessage("Image with this id does not exist");
        }
    }
}
