namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.DeleteProduct;

public interface IDeleteProductStorage
{
    Task DeleteProduct(Guid Id, CancellationToken cancellationToken);
}
