using FluentValidation;

namespace Domain.UseCases.Comment.Command.AddComment;

public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
{
    public AddCommentCommandValidator(IAddCommentStorage addCommentStorage)
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithErrorCode("Name is required");

        RuleFor(x => x.Phone).NotEmpty()
            .WithErrorCode("Phone is required");


        RuleFor(x => x).MustAsync((x, ct) => addCommentStorage.IsUserBoughtProduct(x.ProductId,x.Phone,ct));

        RuleFor(x => x.Text).MaximumLength(256)
            .WithErrorCode("Text is longer than 256 symbols");
        RuleFor(x => x.Rating).InclusiveBetween(0, 5).
            WithErrorCode("Rating must be between 0 and 5");


    }
}
