using Storage.Entities;

namespace Domain.UseCases.Comment.Command.AddComment;

public interface IAddCommentStorage
{
    Task<CommentModel> AddComment(Guid productId, string name, string phone, string text, int rating, CancellationToken cancellationToken);

    Task<bool> IsUserBoughtProduct(Guid productId, string phone, CancellationToken cancellationToken);
}
