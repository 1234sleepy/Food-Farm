using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.Comment.Queries.GetCommentForProduct;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Storages.CommentOperation;

public class GetCommentForProductStorage(DataContext dataContext, IMapper mapper) : IGetCommentForProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public IQueryable<CommentModel> GetCommentsForProduct(GetCommentForProductQuery query, CancellationToken cancellationToken)
    {
        var take = _dataContext.Comments.Where(x => x.ProductId == query.productId).AsNoTracking();
        take = query.Sort switch
        {
            CommentSort.DATE_DESC => take.OrderByDescending(x => x.CreatedAt),
            CommentSort.DATE_ASC => take.OrderBy(x => x.CreatedAt),
            CommentSort.RATING_DESC => take.OrderByDescending(x => x.Rating),
            CommentSort.RATING_ASC => take.OrderBy(x => x.Rating),
            _ => take
        };

        return take.ProjectTo<CommentModel>(_mapper.ConfigurationProvider);
    }
}

