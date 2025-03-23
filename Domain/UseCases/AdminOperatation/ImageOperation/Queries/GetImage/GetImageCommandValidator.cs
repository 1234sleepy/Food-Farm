using FluentValidation;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Queries.GetImage;

public class GetImageCommandValidator : AbstractValidator<GetImageCommand>
{
    public GetImageCommandValidator(IGetImageStorage getImageStorage)
    {
        RuleFor(x => x.imageId)
            .MustAsync(getImageStorage.IsImageExists)
            .WithMessage("Image with this id does not exist");
    }
}
