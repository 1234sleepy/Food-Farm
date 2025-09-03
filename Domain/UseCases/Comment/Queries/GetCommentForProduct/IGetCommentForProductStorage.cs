using Storage.Entities;

namespace Domain.UseCases.Comment.Queries.GetCommentForProduct;

public interface IGetCommentForProductStorage
{
    public IQueryable<CommentModel> GetCommentsForProduct(GetCommentForProductQuery request, CancellationToken cancellationToken);
}
