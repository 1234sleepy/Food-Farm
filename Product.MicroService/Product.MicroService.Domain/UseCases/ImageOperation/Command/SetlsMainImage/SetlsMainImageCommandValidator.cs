using FluentValidation;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.SetlsMainImage;

public class SetlsMainImageCommandValidator : AbstractValidator<SetIsMainImageCommand>
{
    public SetlsMainImageCommandValidator(ISetIsMainImageStorage setIsMainImageStorage)
    {
        RuleFor(x => x.imageId).NotEmpty().WithMessage("Image Id cannot be empty");

        RuleFor(x => x.imageId)
            .MustAsync(setIsMainImageStorage.IsImageExists)
            .WithMessage("Image with this id does not exist");
    }
}
