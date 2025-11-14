using Domain.UseCases.OrderOperation.Command.AddOrder;
using FluentValidation;
using MediatR;
using Storage.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.UseCases.Comment.Command.AddComment;

public class AddCommentCommandHandler(IValidator<AddCommentCommand> validator, IAddCommentStorage storage) : IRequestHandler<AddCommentCommand, CommentModel>
{
    private readonly IValidator<AddCommentCommand> _validator = validator;
    private readonly IAddCommentStorage _storage = storage;
    public async Task<CommentModel> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);
        return await _storage.AddComment(
            request.ProductId,
            request.Name,
            request.Phone,
            request.Text,
            request.Rating,
            cancellationToken);
    }
}
