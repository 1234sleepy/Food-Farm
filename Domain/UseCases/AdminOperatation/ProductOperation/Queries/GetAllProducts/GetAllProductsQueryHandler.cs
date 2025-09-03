using Domain.Extensions;
using Domain.Models;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IGetAllProductsStorage storage, ILogger<GetAllProductsQueryHandler> logger) : IRequestHandler<GetAllProductsQuery, PaginationList<ProductModel>>
{
    private readonly IGetAllProductsStorage _storage = storage;

    public Task<PaginationList<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Handling GetAllProductsQuery with Sort: {Sort}", request.Sort);
        return Task.FromResult(_storage.GetAllProducts(request).AsPagination(request));
    }
}
