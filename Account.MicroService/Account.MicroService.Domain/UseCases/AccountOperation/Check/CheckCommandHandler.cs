using MediatR;

namespace Account.MicroService.Domain.UseCases.AccountOperation.Check;

public class CheckCommandHandler(ICheckStorage checkStorage) : IRequestHandler<CheckCommand, string>
{
    private readonly ICheckStorage _checkStorage = checkStorage;

    public Task<string> Handle(CheckCommand request, CancellationToken cancellationToken)
    {
        return _checkStorage.Check(request.UserId, cancellationToken);
    }
}

