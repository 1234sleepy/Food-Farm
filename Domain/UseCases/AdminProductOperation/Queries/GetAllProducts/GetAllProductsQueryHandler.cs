using Domain.Models;
using Domain.Extensions;
using MediatR;
using Domain.UseCases.AdminProductOperation.Base;

namespace Domain.UseCases.AdminProductOperation.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IGetAllProductsStorage storage) : IRequestHandler<GetAllProductsQuery, PaginationList<ProductModel>>
{
    private readonly IGetAllProductsStorage _storage = storage;
    public Task<PaginationList<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_storage.GetAllProducts(request).AsPagination(request));
    }
}
