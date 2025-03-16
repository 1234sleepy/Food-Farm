namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Command.DeleteProduct;

public interface IDeleteProductStorage
{
    Task DeleteProduct(Guid Id, CancellationToken cancellationToken);
}
