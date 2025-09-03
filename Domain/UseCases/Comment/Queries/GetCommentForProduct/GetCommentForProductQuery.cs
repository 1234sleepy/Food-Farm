using Domain.Models;
using Domain.UseCases.Base;
using MediatR;
using Storage.Entities;

namespace Domain.UseCases.Comment.Queries.GetCommentForProduct;

public record class GetCommentForProductQuery(Guid productId) : PaginationQuery, IRequest<PaginationList<CommentModel>>
{
    public CommentSort? Sort { get; set; }
}

public enum CommentSort
{
    DATE_DESC = 0,
    DATE_ASC = 1,
    RATING_DESC = 2,
    RATING_ASC = 3,
}
