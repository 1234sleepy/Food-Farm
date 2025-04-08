using MediatR;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.DeleteProduct;

public class DeleteProductCommandHandler(IDeleteProductStorage deleteProduct) : IRequestHandler<DeleteProductCommand>
{
    private readonly IDeleteProductStorage _deleteProduct = deleteProduct;
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _deleteProduct.DeleteProduct(request.Id, cancellationToken);
    }
}
