using Domain.Models;
using MediatR;

namespace Domain.UseCases.AdminProductOperation.Command.AddProduct
{
    public record class AddProductCommand(string Name, decimal Price) : IRequest<ProductModel> { } 

}
