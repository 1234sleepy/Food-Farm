namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductPriceQuery;

public interface IGetProductPriceStorage
{
    Task<decimal> GetPrice(Guid id, CancellationToken cancellationToken);
}

