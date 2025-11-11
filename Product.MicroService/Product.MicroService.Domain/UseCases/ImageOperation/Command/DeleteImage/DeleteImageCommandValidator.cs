using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.DeleteImage
{
    public class DeleteImageCommandValidator : AbstractValidator<DeleteImageCommand>
    {
        public DeleteImageCommandValidator(IDeleteImageStorage deleteImageStorage)
        {
            RuleFor(x => x.imageId)
                .NotEmpty().WithMessage("Image Id is required");

            RuleFor(x => x.imageId)
                .MustAsync(deleteImageStorage.IsImageExists)
                .WithMessage("Image with this id does not exist");
        }
    }
}
