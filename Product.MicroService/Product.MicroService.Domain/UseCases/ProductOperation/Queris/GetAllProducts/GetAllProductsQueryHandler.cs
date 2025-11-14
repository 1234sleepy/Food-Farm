using MediatR;
using Microsoft.Extensions.Logging;
using Product.MicroService.Domain.UseCases.Base;
using Product.MicroService.Domain.Extensions;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetAllProducts;

public class GetAllProductsQueryHandler(IGetAllProductsStorage storage, ILogger<GetAllProductsQueryHandler> logger) : IRequestHandler<GetAllProductsQuery, PaginationList<ProductModel>>
{
    private readonly IGetAllProductsStorage _storage = storage;

    public Task<PaginationList<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Handling GetAllProductsQuery with Sort: {Sort}", request.Sort);
        return Task.FromResult(_storage.GetAllProducts(request).AsPagination(request));
    }
}
