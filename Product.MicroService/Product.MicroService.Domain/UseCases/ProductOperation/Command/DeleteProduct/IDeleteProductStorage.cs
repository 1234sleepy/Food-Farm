namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.DeleteProduct;

public interface IDeleteProductStorage
{
    Task DeleteProduct(Guid Id, CancellationToken cancellationToken);
}
