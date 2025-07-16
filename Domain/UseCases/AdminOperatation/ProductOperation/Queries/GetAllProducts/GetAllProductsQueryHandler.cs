using Domain.Extensions;
using Domain.Models;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IGetAllProductsStorage storage) : IRequestHandler<GetAllProductsQuery, PaginationList<ProductModel>>
{
    private readonly IGetAllProductsStorage _storage = storage;

    public Task<PaginationList<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Handling GetAllProductsQuery with Sort: {request.Sort}");
        return Task.FromResult(_storage.GetAllProducts(request).AsPagination(request));
    }
}
