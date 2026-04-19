using MediatR;
using Product.MicroService.Domain.Extensions;
using Product.MicroService.Domain.UseCases.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductsById;

public class GetProductsByIdQueryHandler(IGetProductsByIdStorage storage) : IRequestHandler<GetProductsByIdQuery, List<ProductModel>>
{
    private readonly IGetProductsByIdStorage _storage = storage;

    public Task<List<ProductModel>> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_storage.GetProductsById(request).ToList());
    }
}
