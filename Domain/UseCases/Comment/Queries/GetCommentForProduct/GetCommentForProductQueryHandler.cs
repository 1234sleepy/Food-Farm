using Domain.Extensions;
using Domain.Models;
using Domain.UseCases.Base;
using MediatR;
using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Comment.Queries.GetCommentForProduct;

public class GetCommentForProductQueryHandler(IGetCommentForProductStorage getCommentForProductStorage) : IRequestHandler<GetCommentForProductQuery, PaginationList<CommentModel>>
{
    private readonly IGetCommentForProductStorage _getCommentForProductStorage = getCommentForProductStorage;
    public Task<PaginationList<CommentModel>> Handle(GetCommentForProductQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_getCommentForProductStorage.GetCommentsForProduct(request, cancellationToken).AsPagination(request));
    }
}

