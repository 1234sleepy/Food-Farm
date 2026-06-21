using MediatR;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.LoadProductFile;

public record LoadProductFileCommand(Stream file) : IRequest
{
}
