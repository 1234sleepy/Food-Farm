using MediatR;
using Storage.Entities;

namespace Domain.UseCases.Comment.Command.AddComment;

public record class AddCommentCommand(Guid ProductId, string Name, string Phone, string Text, int Rating) : IRequest<CommentModel>
{

}
