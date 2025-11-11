using MediatR;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
