using Domain.UseCases.AdminProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminProductOperation.Command.AddProduct
{
    public record class AddProductCommand(string Name, decimal Price) : IRequest<ProductModel> { } 

}
