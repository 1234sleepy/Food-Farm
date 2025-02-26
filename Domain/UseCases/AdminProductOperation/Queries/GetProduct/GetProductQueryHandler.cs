using Domain.UseCases.AdminProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminProductOperation.Queries.GetProduct;

public class GetProductQueryHandler(IGetProductStorage getProductStorage) : IRequestHandler<GetProductQuery, ProductModel>
{
    private readonly IGetProductStorage _getProductStorage = getProductStorage;

    public async Task<ProductModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await _getProductStorage.GetProduct(request.Id, cancellationToken);
    }
}
