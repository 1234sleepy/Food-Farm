using MediatR;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.LoadProductFile;

public class LoadProductFileCommandHandler(ILoadProductFile loadProductFile) : IRequestHandler<LoadProductFileCommand>
{
    private readonly ILoadProductFile _loadProductFile = loadProductFile;

    public Task Handle(LoadProductFileCommand request, CancellationToken cancellationToken)
    {
        
    }
}

//json structure of products
//parse them and print them in console