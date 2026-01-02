using MediatR;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductPriceQuery;

public class GetProductPriceQueryHandler(IGetProductPriceStorage getProductPriceStorage) : IRequestHandler<GetProductPriceQuery, decimal>
{
    private  readonly IGetProductPriceStorage _getProductPriceStorage = getProductPriceStorage;
    public async Task<decimal> Handle(GetProductPriceQuery request, CancellationToken cancellationToken)
    {
        return await _getProductPriceStorage.GetPrice(request.Id, cancellationToken);
    }
}
