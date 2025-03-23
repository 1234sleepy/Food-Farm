using FluentValidation;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.DeleteImage;

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
