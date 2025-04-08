using Domain.Models;
using Domain.Extensions;
using MediatR;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IGetAllProductsStorage storage) : IRequestHandler<GetAllProductsQuery, PaginationList<ProductModel>>
{
    private readonly IGetAllProductsStorage _storage = storage;
    public Task<PaginationList<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_storage.GetAllProducts(request).AsPagination(request));
    }
}
